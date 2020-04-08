﻿using System;
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
    /// <inheritdoc cref="IRoomRepository" />
    public class RoomRepository : IRoomRepository
    {
        private readonly FroomContext _context;
        private readonly DbSet<Room> _rooms;

        public RoomRepository(FroomContext context)
        {
            _context = context ?? throw new ArgumentException($"{nameof(FroomContext)} is null.");
            _rooms = _context.Set<Room>();
        }

        public async Task AddAsync(Room room)
        {
            await _rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Room> rooms)
        {
            await _rooms.AddRangeAsync(rooms);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<Room> rooms)
        {
            _rooms.UpdateRange(rooms);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Room> GetAll()
        {
            return _rooms
                .Include(r => r.Building)
                .Include(u => u.Reservations);
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            return await _rooms
                       .Include(u => u.Reservations)
                       .SingleOrDefaultAsync(r => r.Id == id) ??
                   throw new DoesNotExistException($"Room with ID: {id} does not exist.");
        }

        public async Task UpdateAsync(Room room)
        {
            _rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Room room)
        {
            _rooms.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
}