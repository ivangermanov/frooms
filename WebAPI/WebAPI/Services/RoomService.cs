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
        readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task AddRangeAsync(IEnumerable<PostRoomModel> model)
        {
            if (model is null)
                throw new ArgumentException($"{nameof(PostRoomModel)} is null.");

            // TODO: Use Mapper properly
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PostRoomModel, Room>());
            var mapper = config.CreateMapper();

            var rooms = mapper.Map<IEnumerable<Room>>(model);
            await _roomRepository.AddAsync(rooms);
        }

        public IQueryable<RoomDto> GetAvailableRooms(string campus, string buildingName, int floor, DateTime fromDate, DateTime toDate)
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

        public IQueryable<RoomDto> GetRooms(string campus, string buildingName, int? floor)
        {
            // TODO: Fix filtering
            var rooms = _roomRepository.GetAll()
                .Where(r => r.Building.Campus == (campus ?? string.Empty))
                .Where(r => r.BuildingName == (buildingName ?? string.Empty));

            if (floor is null)
                return rooms.Select(r => new RoomDto(r));

            return rooms
                .Where(r => r.Floor == floor)
                .Select(r => new RoomDto(r));
        }
    }
}
