using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Froom.Data.Database;
using Froom.Data.Entities;
using Froom.Data.Exceptions;
using Froom.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Froom.Data.Repositories
{
    /// <inheritdoc cref="IReservationRepository"/>
    public class ReservationRepository : IReservationRepository
    {
        private readonly FroomContext _context;
        private readonly DbSet<Reservation> _reservations;

        public ReservationRepository(FroomContext context)
        {
            _context = context ?? throw new ArgumentException($"{nameof(FroomContext)} is null.");
            _reservations = _context.Set<Reservation>();
        }

        public async Task AddAsync(Reservation reservation)
        {
            await _reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Reservation> GetAll()
        {
            return _reservations
                .Include(r => r.User)
                .Include(r => r.Room)
                    .ThenInclude(room => room.Details);
        }

        public Task<Reservation> GetByIdAsync(int id)
        {
            return _reservations
                .Include(r => r.User)
                .Include(r => r.Room)
                    .ThenInclude(room => room.Details)
                .SingleOrDefaultAsync(r => r.Id == id) ??
                throw new DoesNotExistException($"Reservation with ID: {id} does not exist");
        }

        public IQueryable<Reservation> GetForUser(Guid Id)
        {
            return _reservations
                .Include(r => r.User)
                .Include(r => r.Room)
                    .ThenInclude(room => room.Details)
                .Where(r => r.UserId == Id);
        }

        public async Task RemoveAsync(Reservation reservation)
        {
            _reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            _reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateRangeAsync(IEnumerable<Reservation> reservation)
        {
            _reservations.UpdateRange(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
