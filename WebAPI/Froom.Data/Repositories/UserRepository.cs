using Froom.Data.Database;
using Froom.Data.Entities;
using Froom.Data.Exceptions;
using Froom.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Froom.Data.Repositories
{
    /// <inheritdoc cref="IUserRepository"/>
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _users;
        private readonly FroomContext _context;

        public UserRepository(FroomContext context)
        {
            _context = context ?? throw new ArgumentException($"{nameof(FroomContext)} is null.");
            _users = _context.Set<User>();
        }

        public async Task AddAsync(User user)
        {
            await _users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public IQueryable<User> GetAll()
        {
            return _users.Include(u => u.Reservations);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _users
                .Include(u => u.Reservations)
                .SingleOrDefaultAsync(u => u.Id == id) ??
                throw new DoesNotExistException($"User with ID: {id} does not exist.");
        }

        public async Task Update(User user)
        {
            _users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
