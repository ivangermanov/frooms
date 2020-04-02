using Froom.Data.Dtos;
using Froom.Data.Entities;
using Froom.Data.Models.Rooms;
using Froom.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    /// <inheritdoc cref="IRoomService"/>
    public class RoomService : IRoomService
    {
        readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task AddRangeAsync(IEnumerable<PostRoomModel> model)
        {
            // TODO: Use Mapper properly
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PostRoomModel, Room>());
            var mapper = config.CreateMapper();

            var rooms = mapper.Map<IEnumerable<Room>>(model);
            await _roomRepository.AddAsync(rooms);
        }

        public async Task<IEnumerable<RoomDto>> GetRooms(string? campus, string? buildingName, int? floor)
        {
            var rooms = _roomRepository.GetAll()
                .Where(r => string.IsNullOrEmpty(campus) || r.Building.Campus.Equals(campus))
                .Where(r => string.IsNullOrEmpty(buildingName) || r.BuildingName.Equals(buildingName))
                .Where(r => !floor.HasValue || r.Floor == floor);

            var dtos = await rooms.Select(r => new RoomDto(r)).ToListAsync();

            return dtos;
        }

        public async Task<IEnumerable<RoomDto>> GetRooms(string campus, string buildingName, int floor, DateTime fromDate, DateTime toDate)
        {
            if (campus == null || buildingName == null)
                throw new ArgumentNullException("The campus or the building name was null.");

            if (fromDate > toDate)
                throw new ArgumentException("The start DateTime cannot be after the end DateTime.");

            IQueryable<RoomDto> rooms = _roomRepository.GetAll()
                .Where(r => r.Building.Campus == campus &&
                            r.BuildingName == buildingName &&
                            r.Floor == floor &&
                            r.IsAvailable(fromDate, toDate))
                .Select(r => new RoomDto(r));

            return rooms;
        }

    }
}
