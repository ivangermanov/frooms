using Froom.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Froom.Data.Repositories.Interfaces
{
    public interface IFloorRepository
    {
        /// <summary>
        /// Adds a generic floor to the database context.
        /// </summary>
        /// <param name="floor"> The floor to be added.</param>
        Task AddAsync(Floor floor);

        /// <summary>
        /// Adds a floor to a building in the database context.
        /// </summary>
        /// <param name="buildingName"> The name of the building.</param>
        /// <param name="floorNumber"> The floor number to be added.</param>
        Task AddForBuildingAsync(string buildingName, string floorNumber);

        /// <summary>
        /// Gets all floor numbers from the database context.
        /// </summary>
        IQueryable<string> GetAllNumbers();

        /// <summary>
        /// Gets all floors for a specific building.
        /// </summary>
        /// <param name="buildingName"> The building name to get the floors for.</param>
        IQueryable<Floor> GetForBuildingAsync(string buildingName);
    }
}
