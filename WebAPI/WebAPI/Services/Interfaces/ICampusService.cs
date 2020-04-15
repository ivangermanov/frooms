using Froom.Data.Dtos;
using Froom.Data.Models.Campuses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public interface ICampusService
    {
        /// <summary>
        /// Adds a new campus.
        /// </summary>
        /// <param name="model">The campus to be added.</param>
        public Task AddCampusAsync(PostCampusModel model);

        /// <summary>
        /// Get all the campuses.
        /// </summary>
        public Task<IEnumerable<CampusDto>> GetCampuses();

        /// <summary>
        /// Remove a campus by name.
        /// </summary>
        /// <param name="name">The name of the campus to be deleted.</param>
        public Task RemoveCampus(string name);

        /// <summary>
        /// Remove a campus by name.
        /// </summary>
        /// <param name="name">The id of the campus to be deleted.</param>
        public Task RemoveCampus(int id);
    }
}
