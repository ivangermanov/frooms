using Froom.Data.Dtos;
using Froom.Data.Entities;
using Froom.Data.Models.Rooms;
using Froom.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                throw new ArgumentException($"{nameof(PostRoomModel)} is null.");

            var newRoom = new Room
            {
                Number = model.Number,
                Floor = model.Floor,
                BuildingName = model.BuildingName,
                Capacity = model.Capacity,
                Reservations = new List<Reservation>(),
                Points = model.Points,
            };

            await _roomRepository.AddAsync(newRoom);
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
            if (campus == null || buildingName == null)
                throw new ArgumentNullException("The campus or the building name was null.");

            IQueryable<Room> rooms = _roomRepository
                                        .GetAll()
                                        .Where(r => r.Building.Campus == campus && r.BuildingName == buildingName);

            if (floor is null)
                return rooms.Select(r => new RoomDto(r));

            return rooms
                .Where(r => r.Floor == floor)
                .Select(r => new RoomDto(r));
        }
    }
}
