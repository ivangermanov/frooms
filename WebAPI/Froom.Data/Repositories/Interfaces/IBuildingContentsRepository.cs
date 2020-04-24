using Froom.Data.Entities;
using System.Threading.Tasks;

namespace Froom.Data.Repositories.Interfaces
{
    public interface IBuildingContentsRepository
    {
        /// <summary>
        /// Gets the ID of the <see cref="BuildingContents"/> with the specific campus, building and floor.
        /// </summary>
        /// <param name="campusName">The name of the campus</param>
        /// <param name="buildingName">The name of the building</param>
        /// <param name="floorNumber">The floor number</param>
        /// <returns></returns>
        public Task<int> GetIdAsync(string campusName, string buildingName, string floorNumber);
    }
}
