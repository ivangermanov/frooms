using AutoMapper;
using Froom.Data.Dtos;
using Froom.Data.Entities;
using Froom.Data.Models.Reservations;
using Froom.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    /// <inheritdoc cref="IReservationService"/>
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public ReservationService(
            IReservationRepository reservationRepository,
            INotificationRepository notificationRepository,
            IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task AddReservationAsync(PostReservationModel model)
        {
            if (model is null)
                throw new ArgumentException($"{nameof(PostReservationModel)} is null.");

            var reservation = _mapper.Map<Reservation>(model);
            await _reservationRepository.AddAsync(reservation);

            reservation = await _reservationRepository.GetByIdAsync(reservation.Id);

            var notification = new Notification()
            {
                UserId = reservation.UserId,
                Title = "Reservation created",
                Message = $"{reservation.Room.Details.BuildingName}_" +
                    $"{reservation.Room.Number}, " +
                    $"{reservation.Room.Details.CampusName} " +
                    $"for {reservation.StartDate: MM/dd/yy H:mm}"
            };

            await _notificationRepository.AddAsync(notification);
        }

        public async Task<IEnumerable<ReservationDto>> GetReservationsForRoom(int roomId)
        {
            var reservations = _reservationRepository.GetAll()
                .Where(r => r.RoomId == roomId);

            return await _mapper.ProjectTo<ReservationDto>(reservations).ToListAsync();
        }

        public async Task<IEnumerable<ReservationDto>> GetReservationsForUser(Guid userId)
        {
            var reservations = _reservationRepository.GetForUser(userId).Select(e => new ReservationDto
            {
                Room = _mapper.Map<RoomDto>(e.Room),
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Expired = e.IsExpired()
            });

            return await reservations.ToListAsync();
        }

        public async Task<IEnumerable<ReservationDto>> GetAllReservations()
        {
            var reservations = _reservationRepository.GetAll();

            return await _mapper.ProjectTo<ReservationDto>(reservations).ToListAsync();
        }
    }
}
