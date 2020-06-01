using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Froom.Data.Dtos;
using Froom.Data.Entities;
using Froom.Data.Models.Rooms;
using Froom.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    /// <inheritdoc cref="IRoomService" />
    public class RoomService : IRoomService
    {
        private readonly IBuildingContentsRepository _detailsRepository;
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;

        public RoomService(
            IRoomRepository roomRepository,
            IBuildingContentsRepository detailsRepository,
            IMapper mapper)
        {
            _roomRepository = roomRepository;
            _detailsRepository = detailsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FloorMapRoomDTO>> GetFloormapRooms(string? campus, string? building,
            string? floor, DateTime? fromDate,
            DateTime? toDate)
        {
            var rooms = await _roomRepository.GetAll()
                .Where(r => string.IsNullOrEmpty(campus) || r.Details.Building.CampusName.Equals(campus))
                .Where(r => string.IsNullOrEmpty(building) || r.Details.BuildingName.Equals(building))
                .Where(r => string.IsNullOrEmpty(floor) || r.Details.FloorNumber == floor).ToListAsync();

            var dto = new List<FloorMapRoomDTO>(rooms.Count);
            foreach (var room in rooms)
            {
                var mapped = _mapper.Map<FloorMapRoomDTO>(room);
                mapped.IsAvailable = room.IsAvailable(fromDate, toDate);
                dto.Add(mapped);
            }

            return dto;
        }

        public async Task<IEnumerable<RoomDto>> GetAvailableRooms(
            string campus,
            string building,
            string floor,
            DateTime fromDate,
            DateTime toDate)
        {
            if (campus == null || building == null)
                throw new ArgumentNullException("The campus or the building name was null.");

            if (fromDate > toDate)
                throw new ArgumentException("The start DateTime cannot be after the end DateTime.");
            var rooms = await _roomRepository.GetAll()
                .Where(r => r.Details.Building.CampusName == campus &&
                            r.Details.BuildingName == building &&
                            r.Details.FloorNumber == floor).ToListAsync();

            rooms = rooms.Where(r => r.IsAvailable(fromDate, toDate)).ToList();

            return _mapper.Map<IEnumerable<RoomDto>>(rooms);
        }

        public async Task AddRangeAsync(IEnumerable<PostRoomModel> models)
        {
            var rooms = _mapper.Map<IEnumerable<Room>>(models, opts => opts.Items["DetailsId"] = GetDetailsId(models));
            await _roomRepository.AddRangeAsync(rooms);
        }

        public async Task UpdateRangeAsync(IEnumerable<PostRoomModel> models)
        {
            var rooms = _mapper.Map<IEnumerable<Room>>(models, opts => opts.Items["DetailsId"] = GetDetailsId(models));

            var dbRooms = new List<Room>();

            foreach (var room in rooms)
                dbRooms.Add(await _roomRepository.GetEntityAsync(room));

            foreach (var room in dbRooms)
            {
                var model = rooms.Where(x => x.Number == room.Number && x.DetailsId == room.DetailsId).Single();

                room.Capacity = model.Capacity;
                room.Points = model.Points;
            }

            await _roomRepository.UpdateRangeAsync(dbRooms);
        }

        public async Task RemoveRangeAsync(IEnumerable<DeleteRoomModel> models)
        {
            var rooms = _mapper.Map<IEnumerable<Room>>(models, opts => opts.Items["DetailsId"] = GetDetailsId(models));

            var dbRooms = new List<Room>();

            foreach (var room in rooms)
                dbRooms.Add(await _roomRepository.GetEntityAsync(room));

            await _roomRepository.RemoveRangeAsync(dbRooms);
        }

        private async Task<Dictionary<PostRoomModel, int>> GetDetailsId(IEnumerable<PostRoomModel> models)
        {
            var detailsId = new Dictionary<PostRoomModel, int>();

            foreach (var m in models.ToList())
                detailsId.Add(m, await _detailsRepository.GetIdAsync(m.CampusName, m.BuildingName, m.FloorNumber));

            return detailsId;
        }

        private async Task<Dictionary<DeleteRoomModel, int>> GetDetailsId(IEnumerable<DeleteRoomModel> models)
        {
            var detailsId = new Dictionary<DeleteRoomModel, int>();

            foreach (var m in models.ToList())
                detailsId.Add(m, await _detailsRepository.GetIdAsync(m.CampusName, m.BuildingName, m.FloorNumber));

            return detailsId;
        }
    }
}