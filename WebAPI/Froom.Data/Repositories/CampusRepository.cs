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
    public class CampusRepository : ICampusRepository
    {
        private readonly FroomContext _context;
        private readonly DbSet<Campus> _campuses;

        public CampusRepository(FroomContext context)
        {
            _context = context ?? throw new ArgumentException($"{nameof(FroomContext)} is null.");
            _campuses = _context.Set<Campus>();
        }

        public async Task AddAsync(Campus campus)
        {
            await _campuses.AddAsync(campus);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Campus> GetAll()
        {
            return _campuses
                .Include(c => c.Buildings);
        }

        public async Task<Campus> GetAsync(int id)
        {
            return await _campuses
                .Include(c => c.Buildings)
                .SingleOrDefaultAsync(c => c.Id == id) ??
                throw new DoesNotExistException($"Campus with ID: {id} does not exist.");
        }

        public async Task<Campus> GetAsync(string name)
        {
            return await _campuses
                .Include(c => c.Buildings)
                .SingleOrDefaultAsync(c => c.Name == name) ??
                throw new DoesNotExistException($"Campus with name: {name} does not exist.");
        }

        public async Task RemoveAsync(Campus campus)
        {
            DbSet<Building> _buildings = _context.Set<Building>();

            foreach(Building b in campus.Buildings)
            {
                _buildings.Remove(b);
            }

            _campuses.Remove(campus);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Campus campus)
        {
            _campuses.Update(campus);
            await _context.SaveChangesAsync();
        }
    }
}
