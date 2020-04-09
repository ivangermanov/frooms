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
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task AddReservationAsync(PostReservationModel model)
        {
            if (model is null)
                throw new ArgumentException($"{nameof(PostReservationModel)} is null.");

            var reservation = _mapper.Map<Reservation>(model);

            await _reservationRepository.AddAsync(reservation);
        }

        public async Task<IEnumerable<ReservationDto>> GetReservationsForRoom(int roomId)
        {
            var reservations = _reservationRepository.GetAll()
                .Where(r => r.RoomId == roomId);

            return await _mapper.ProjectTo<ReservationDto>(reservations).ToListAsync();
        }

        public async Task<IEnumerable<ReservationDto>> GetReservationsForUser(int userNumber)
        {
            var reservations = _reservationRepository.GetAll()
                .Where(r => r.UserNumber == userNumber);

            return await _mapper.ProjectTo<ReservationDto>(reservations).ToListAsync();
        }
    }
}
