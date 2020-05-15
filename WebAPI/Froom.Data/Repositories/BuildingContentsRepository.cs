using Froom.Data.Database;
using Froom.Data.Entities;
using Froom.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Froom.Data.Repositories
{
    /// <inheritdoc cref="IBuildingContentsRepository"/>
    public class BuildingContentsRepository : IBuildingContentsRepository
    {
        private readonly FroomContext _context;
        private readonly DbSet<BuildingContents> _buildingContents;

        public BuildingContentsRepository(FroomContext context)
        {
            _context = context ?? throw new ArgumentException($"{nameof(FroomContext)} is null.");
            _buildingContents = _context.Set<BuildingContents>();
        }

        public async Task<int> GetIdAsync(string campusName, string buildingName, string floorNumber)
        {
            return (await _buildingContents.AsNoTracking()
                .SingleAsync(b => b.CampusName == campusName
                    && b.BuildingName == buildingName
                    && b.FloorNumber == floorNumber)).Id;
        }
    }
}
