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
        private readonly IRoomRepository _roomRepository;
        private readonly IBuildingContentsRepository _detailsRepository;
        private readonly IMapper _mapper;

        public RoomService(
            IRoomRepository roomRepository,
            IBuildingContentsRepository detailsRepository,
            IMapper mapper)
        {
            _roomRepository = roomRepository;
            _detailsRepository = detailsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomDto>> GetRooms(string? campus, string? building, string? floor)
        {
            var rooms = _roomRepository.GetAll()
                .Where(r => string.IsNullOrEmpty(campus) || r.Details.Building.CampusName.Equals(campus))
                .Where(r => string.IsNullOrEmpty(building) || r.Details.BuildingName.Equals(building))
                .Where(r => string.IsNullOrEmpty(floor) || r.Details.FloorNumber == floor);

            return await _mapper.ProjectTo<RoomDto>(rooms).ToListAsync();
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

            var rooms = _roomRepository.GetAll()
                .Where(r => r.Details.Building.CampusName == campus &&
                            r.Details.BuildingName == building &&
                            r.Details.FloorNumber == floor &&
                            r.IsAvailable(fromDate, toDate));

            return await _mapper.ProjectTo<RoomDto>(rooms).ToListAsync();
        }

        public async Task AddRangeAsync(IEnumerable<PostRoomModel> model)
        {
            var rooms = _mapper.Map<IEnumerable<Room>>(model, opts => opts.Items["DetailsId"] = GetDetailsId(model));
            await _roomRepository.AddRangeAsync(rooms);
        }

        public async Task UpdateRangeAsync(IEnumerable<PostRoomModel> model)
        {
            var rooms = _mapper.Map<IEnumerable<Room>>(model, opts => opts.Items["DetailsId"] = GetDetailsId(model));
            await _roomRepository.UpdateRangeAsync(rooms);
        }

        public async Task RemoveRangeAsync(IEnumerable<DeleteRoomModel> model)
        {
            var rooms = _mapper.Map<IEnumerable<Room>>(model, opts => opts.Items["DetailsId"] = GetDetailsId(model));

            var dbRooms = new List<Room>(rooms.Count());

            foreach (var room in rooms)
                dbRooms.Add(await _roomRepository.FindAsync(room));

            await _roomRepository.RemoveRangeAsync(dbRooms);
        }

        private async Task<Dictionary<PostRoomModel, int>> GetDetailsId(IEnumerable<PostRoomModel> models)
        {
            var detailsId = new Dictionary<PostRoomModel, int>();

            foreach (var m in models.ToList())
            {
                detailsId.Add(m, await _detailsRepository.GetIdAsync(m.CampusName, m.BuildingName, m.FloorNumber));
            }

            return detailsId;
        }

        private async Task<Dictionary<DeleteRoomModel, int>> GetDetailsId(IEnumerable<DeleteRoomModel> models)
        {
            var detailsId = new Dictionary<DeleteRoomModel, int>();

            foreach (var m in models.ToList())
            {
                detailsId.Add(m, await _detailsRepository.GetIdAsync(m.CampusName, m.BuildingName, m.FloorNumber));
            }

            return detailsId;
        }
    }
}