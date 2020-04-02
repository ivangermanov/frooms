using Froom.Data.Dtos;
using Froom.Data.Entities;
using Froom.Data.Models.Reservations;
using Froom.Data.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    /// <inheritdoc cref="IReservationService"/>
    public class ReservationService : IReservationService
    {
        IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task AddReservationAsync(PostReservationModel model)
        {
            if (model is null)
                throw new ArgumentException($"{nameof(PostReservationModel)} is null.");

            var newReservation = new Reservation()
            {
                UserNumber = model.UserNumber,
                RoomId = model.RoomId,
                StartTime = model.StartTime,
                Duration = model.Duration
            };

            await _reservationRepository.AddAsync(newReservation);
        }

        public IQueryable<ReservationDto> GetReservationsForRoom(int roomId)
        {
            return _reservationRepository.GetAll()
                .Where(r => r.RoomId == roomId)
                .Select(r => new ReservationDto(r));
        }

        public IQueryable<ReservationDto> GetReservationsForUser(int userNumber)
        {
            return _reservationRepository.GetAll()
                .Where(r => r.UserNumber == userNumber)
                .Select(r => new ReservationDto(r));
        }
    }
}
