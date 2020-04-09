using System;
using System.Linq;
using System.Threading.Tasks;
using Froom.Data.Database;
using Froom.Data.Entities;
using Froom.Data.Exceptions;
using Froom.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Froom.Data.Repositories
{
    /// <inheritdoc cref="IBuildingRepository"/>
    class BuildingRepository : IBuildingRepository
    {
        private readonly FroomContext _context;
        private readonly DbSet<Building> _buildings;

        public BuildingRepository(FroomContext context)
        {
            _context = context ?? throw new ArgumentException($"{nameof(FroomContext)} is null.");
            _buildings = _context.Set<Building>();
        }

        public async Task AddAsync(Building building)
        {
            await _buildings.AddAsync(building);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Building> GetAll()
        {
            return _buildings
                .Include(b => b.Rooms);
        }

        public async Task<Building> GetByIdAsync(int id)
        {
            return await _buildings
                .Include(u => u.Rooms)
                .SingleOrDefaultAsync(r => r.Id == id) ??
                throw new DoesNotExistException($"Building with ID: {id} does not exist.");
        }

        public IQueryable<Building> GetForCampusAsync(string campus)
        {
            return _buildings
                .Include(u => u.Rooms)
                .Where(r => r.Campus == campus);
        }

        public async Task RemoveAsync(Building building)
        {
            _buildings.Remove(building);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Building building)
        {
            _buildings.Update(building);
            await _context.SaveChangesAsync();
        }
    }
}
