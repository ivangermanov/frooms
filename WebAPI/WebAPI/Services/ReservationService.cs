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
using AutoMapper.Configuration.Annotations;
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
            var overlapping = await _reservationRepository.GetAll()
                .Where(r => r.StartDate.CompareTo(reservation.EndDate)<=0)
                .Where(r=>reservation.StartDate.CompareTo(r.EndDate)<=0)
                .Where(r=>r.Id.CompareTo(reservation.Id)!=0)
                .ToListAsync();

            //flag all of them as cancelled
            overlapping.ForEach((reservation1 => reservation1.IsCancelled=true));
            await _reservationRepository.UpdateRangeAsync(overlapping);
            await _reservationRepository.UpdateAsync(reservation);

            //find reservation information
            var oldReservationData = await _reservationRepository.GetByIdAsync(reservation.Id);

            //check if the user is different
            if (oldReservationData.User.Id != reservationAdmin.UserId)
            {
                //notify old user
                await _notificationRepository.AddAsync(new Notification(){
                    UserId = oldReservationData.User.Id,
                    Title =  "Reservation cancelled",
                    Message = $"One of your reservations got cancelled!"
                });

                //notify new user
                await _notificationRepository.AddAsync(new Notification()
                {
                    UserId = reservationAdmin.UserId,
                    Title = "A reservation was assigned to you",
                    Message = "You have a new reservation!"
                });
            }

            //notify user for data change
            await _notificationRepository.AddAsync(new Notification()
            {
                UserId = reservationAdmin.UserId,
                Title = "Reservation data changed",
                Message = $"Reservation data changed"

            });

            //notify all datat changes
            overlapping.ForEach(reservation1 =>
                _notificationRepository.AddAsync(new Notification()
                    {
                        UserId = reservationAdmin.UserId,
                        Title = "Reservation data changed",
                        Message = $"Reservation cancelled"
                    }));
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
                MaxForwardReservationPeriod = ReservationRules.MaxForwardReservationPeriod.TotalMilliseconds
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
            var reservations = _reservationRepository.GetForUser(userId).Select(e => new ReservationDto
            {
                Id = e.Id,
                Room = _mapper.Map<RoomDto>(e.Room),
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Expired = e.IsExpired(),
                IsCancelled = e.IsCancelled,
                User = _mapper.Map<UserDto>(e.User)
            });

            return await reservations.ToListAsync();
        }

        public async Task<IEnumerable<ReservationDto>> GetAllReservations()
        {
            var reservations = _reservationRepository.GetAll().Select(e => new ReservationDto
            {
                Id = e.Id,
                Room = _mapper.Map<RoomDto>(e.Room),
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Expired = e.IsExpired(),
                IsCancelled = e.IsCancelled,
                User = _mapper.Map<UserDto>(e.User)
            });
            return await reservations.ToListAsync();
        }

        public async Task CancelReservation(int idOfReservationToDeleteData)
        {
            var reservationToDelete = await _reservationRepository.GetByIdAsync(idOfReservationToDeleteData);
            reservationToDelete.IsCancelled = true;
            await _reservationRepository.UpdateAsync(reservationToDelete);
        }
    }
}
