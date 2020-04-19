using Froom.Data.Dtos;
using Froom.Data.Models.Buildings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public interface IBuildingService
    {
        /// <summary>
        /// Adds a new building.
        /// </summary>
        /// <param name="model">The building to be added.</param>
        public Task AddBuildingAsync(PostBuildingModel model);

        /// <summary>
        /// Get all the buildings for a campus.
        /// </summary>
        public Task<IEnumerable<BuildingDto>> GetBuildingsForCampus(string campusName);

        /// <summary>
        /// Remove a building by id.
        /// </summary>
        /// <param name="id">The id of the building to be deleted.</param>
        public Task RemoveBuilding(int id);
    }
}
