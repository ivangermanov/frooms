using Froom.Data.Dtos;
using Froom.Data.Entities;
using Froom.Data.Models.Rooms;
using Froom.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    /// <inheritdoc cref="IRoomService"/>
    public class RoomService : IRoomService
    {
        IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task AddRoomAsync(PostRoomModel model)
        {
            if (model is null)
            {
                throw new ArgumentException($"{nameof(PostRoomModel)} is null.");
            }

            // TODO: Use Mapper properly
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PostRoomModel, Room>());
            var mapper = config.CreateMapper();

            var room = mapper.Map<Room>(model);
            await _roomRepository.AddAsync(room);
        }

        public IQueryable<RoomDto> FilterRooms(string? campus, string? buildingName, int? floor)
        {
            var rooms = _roomRepository.GetAll()
                .Where(r => r.Building.Campus == (campus ?? string.Empty))
                .Where(r => r.BuildingName == (buildingName ?? string.Empty));

            if (floor == null)
                return rooms.Select(r => new RoomDto(r, r.Building.Campus));

            return rooms
                .Where(r => r.Floor == floor)
                .Select(r => new RoomDto(r, r.Building.Campus));
        }
    }
}
