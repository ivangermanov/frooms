using System;
using System.Linq;
using System.Threading.Tasks;
using Froom.Data.Database;
using Froom.Data.Entities;
using Froom.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Froom.Data.Repositories
{
    internal class RoomRepository : IRoomRepository
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

        public IQueryable<Room> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Room> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Room room)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Room room)
        {
            throw new NotImplementedException();
        }
    }
}