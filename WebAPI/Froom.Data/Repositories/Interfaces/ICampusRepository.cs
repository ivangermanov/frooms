using Froom.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Froom.Data.Repositories.Interfaces
{
    public interface ICampusRepository
    {
        /// <summary>
        /// Adds a campus to the database context.
        /// </summary>
        /// <param name="campus"> The campus to be added.</param>
        Task AddAsync(Campus campus);

        /// <summary>
        /// Gets all campuses from the database context.
        /// Includes the buildings.
        /// </summary>
        IQueryable<Campus> GetAll();

        /// <summary>
        /// Gets the names of all campuses from the database context.
        /// </summary>
        IQueryable<string> GetNames();

        /// <summary>
        /// Gets a campus by id from the database context.
        /// </summary>
        /// <param name="id"> The id of the campus.</param>
        Task<Campus> GetByIdAsync(int id);

        /// <summary>
        /// Gets a campus by id from the database context.
        /// </summary>
        /// <param name="name"> The name of the campus.</param>
        Task<Campus> GetByName(string name);

        /// <summary>
        /// Updates information about a campus.
        /// </summary>
        /// <param name="campus"> The campus to be updated.</param>
        Task UpdateAsync(Campus campus);

        /// <summary>
        /// Removes a campus
        /// </summary>
        /// <param name="campus"> The campus to be removed.</param>
        Task RemoveAsync(Campus campus);
    }
}
