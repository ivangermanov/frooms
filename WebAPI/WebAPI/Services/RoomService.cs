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
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomDto>> GetRooms(string? campus, string? buildingName, int? floor)
        {
            var rooms = _roomRepository.GetAll()
                .Where(r => string.IsNullOrEmpty(campus) || r.Building.Campus.Equals(campus))
                .Where(r => string.IsNullOrEmpty(buildingName) || r.BuildingName.Equals(buildingName))
                .Where(r => !floor.HasValue || r.Floor == floor);

            return await _mapper.ProjectTo<RoomDto>(rooms).ToListAsync();
        }

        public async Task<IEnumerable<RoomDto>> GetAvailableRooms(string campus, string buildingName, int floor,
            DateTime fromDate, DateTime toDate)
        {
            if (campus == null || buildingName == null)
                throw new ArgumentNullException("The campus or the building name was null.");

            if (fromDate > toDate)
                throw new ArgumentException("The start DateTime cannot be after the end DateTime.");

            var rooms = _roomRepository.GetAll()
                .Where(r => r.Building.Campus == campus &&
                            r.BuildingName == buildingName &&
                            r.Floor == floor &&
                            r.IsAvailable(fromDate, toDate));

            return await _mapper.ProjectTo<RoomDto>(rooms).ToListAsync();
        }

        public async Task AddAsync(PostRoomModel model)
        {
            var room = _mapper.Map<Room>(model);
            await _roomRepository.AddAsync(room);
        }

        public async Task AddRangeAsync(IEnumerable<PostRoomModel> model)
        {
            var rooms = _mapper.Map<IEnumerable<Room>>(model);
            await _roomRepository.AddRangeAsync(rooms);
        }

        public async Task UpdateRangeAsync(IEnumerable<PostRoomModel> model)
        {
            var rooms = _mapper.Map<IEnumerable<Room>>(model);
            await _roomRepository.UpdateRangeAsync(rooms);
        }

        public async Task RemoveRangeAsync(IEnumerable<DeleteRoomModel> model)
        {
            var rooms = _mapper.Map<IEnumerable<Room>>(model);

            var dbRooms = new List<Room>(rooms.Count());

            foreach (var room in rooms)
                dbRooms.Add(await _roomRepository.FindAsync(room));

            await _roomRepository.RemoveRangeAsync(dbRooms);
        }
    }
}