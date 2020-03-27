using Froom.Data.Dtos.Rooms;
using Froom.Data.Entities;
using Froom.Data.Models;
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

        public async Task AddAsync(PostRoomModel model)
        {
            if (model is null)
            {
                throw new ArgumentException($"{nameof(PostRoomModel)} is null.");
            }

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

        public IQueryable<RoomDto> Rooms()
        {
           return _roomRepository.GetAll().Select(r => new RoomDto(r, r.Building.Campus));
        }
    }
}
