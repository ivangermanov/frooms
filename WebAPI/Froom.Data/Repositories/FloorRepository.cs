using Froom.Data.Database;
using Froom.Data.Entities;
using Froom.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Froom.Data.Repositories
{
    /// <inheritdoc cref="IFloorRepository"/>
    public class FloorRepository : IFloorRepository
    {
        private readonly FroomContext _context;
        private readonly DbSet<Floor> _floors;
        private readonly DbSet<BuildingContents> _buildingFloorRooms;

        public FloorRepository(FroomContext context)
        {
            _context = context ?? throw new ArgumentException($"{nameof(FroomContext)} is null.");
            _floors = _context.Set<Floor>();
            _buildingFloorRooms = _context.Set<BuildingContents>();
        }

        public async Task AddAsync(Floor floor)
        {
            await _context.AddAsync(floor);
            await _context.SaveChangesAsync();
        }

        public async Task AddForBuildingAsync(string buildingName, string floorNumber)
        {
            var newFloorForBuilding = new BuildingContents()
            {
                BuildingName = buildingName,
                FloorNumber = floorNumber
            };

            await _context.AddAsync(newFloorForBuilding);
            await _context.SaveChangesAsync();
        }

        public IQueryable<string> GetAllNumbers()
        {
            return _floors.Select(f => f.Number);
        }

        public IQueryable<Floor> GetForBuildingAsync(string buildingName)
        {
            return _buildingFloorRooms
                .Where(e => e.BuildingName == buildingName)
                .Select(e => e.Floor);
        }
    }
}
