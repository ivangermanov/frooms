using Froom.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Froom.Data.Repositories.Interfaces
{
    public interface IBuildingRepository
    {
        /// <summary>
        /// Adds a building to the database context.
        /// </summary>
        /// <param name="building"> The building to be added.</param>
        Task<Building> AddAsync(Building building);

        /// <summary>
        /// Gets all reservations from the database context.
        /// </summary>
        IQueryable<Building> GetAll();

        /// <summary>
        /// Gets a building by id from the database context.
        /// </summary>
        /// <param name="id"> The id of the building.</param>
        Task<Building> GetByIdAsync(int id);

        /// <summary>
        /// Gets all reservations for a specific user.
        /// </summary>
        /// <param name="campus"> The campus to get the building for.</param>
        IQueryable<Building> GetForCampus(FontysCampus campus);

        /// <summary>
        /// Updates information about a building.
        /// </summary>
        /// <param name="building"> The building to be updated.</param>
        Task Update(Building building);

        /// <summary>
        /// Updates information about a building.
        /// </summary>
        /// <param name="building"> The building to be updated.</param>
        Task RemoveAsync(Building building);
    }
}
