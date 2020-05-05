using System.Collections.Generic;
using Froom.Data.Dtos;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public interface IFloorService
    {
        /// <summary>
        /// Gets the floors for a given building by building name.
        /// </summary>
        /// <param name="buildingName">The building name whose floors will be fetched.</param>
        public Task<IEnumerable<FloorDto>> GetFloors(string buildingName);
    }
}