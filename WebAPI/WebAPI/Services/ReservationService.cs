﻿using AutoMapper;
using Froom.Data.Dtos;
using Froom.Data.Entities;
using Froom.Data.Models.Reservations;
using Froom.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Helpers;
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

        

        public async Task UpdateReservation(AdminUpdateReservationModel reservationAdmin)
        {
            //TODO: Implement overriding conflicts
            var reservation = _mapper.Map<Reservation>(reservationAdmin);

            //fetch all the reservations in that segment


            //flag all of them as cancelled



            await _reservationRepository.UpdateAsync(reservation);
        }

        public ReservationRulesDto GetReservationRules()
        {
            return new ReservationRulesDto()
            {
                CurrentDate = ReservationRules.CurrentDate,
                MinTime = ReservationRules.MinTime,
                MaxTime = ReservationRules.MaxTime,
                AvailableDays = ReservationRules.AvailableDays,
                MinReservationTime = ReservationRules.MinReservationTime.TotalMilliseconds,
                MaxReservationTime = ReservationRules.MaxReservationTime.TotalMilliseconds,
                MaxForwardReservationPeriod = ReservationRules.MaxForwardReservationPeriod
            };
        }

        public async Task<IEnumerable<ReservationDto>> GetReservationsForRoom(int roomId)
        {
            var reservations = _reservationRepository.GetAll()
                .Where(r => r.RoomId == roomId);

            return await _mapper.ProjectTo<ReservationDto>(reservations).ToListAsync();
        }

        public async Task<IEnumerable<ReservationDto>> GetReservationsForUser(Guid userId)
        {
            var reservations = _reservationRepository.GetForUser(userId);
            return await _mapper.ProjectTo<ReservationDto>(reservations).ToListAsync();
        }

        public async Task<IEnumerable<ReservationDto>> GetAllReservations()
        {
            var reservations = _reservationRepository.GetAll();

            return await _mapper.ProjectTo<ReservationDto>(reservations).ToListAsync();
        }

        public async Task DeleteReservation(int idOfReservationToDeleteData)
        {
            var reservationToDelete = await _reservationRepository.GetByIdAsync(idOfReservationToDeleteData);

            await _reservationRepository.RemoveAsync(reservationToDelete);
        }
    }
}
