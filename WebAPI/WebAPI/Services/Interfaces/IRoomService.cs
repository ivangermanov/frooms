using Froom.Data.Dtos;
using Froom.Data.Models.Rooms;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public interface IRoomService
    {
        /// <summary>
        /// Adds a new room.
        /// </summary>
        /// <param name="model">The room that needs to be added.</param>
        public Task AddRoomAsync(PostRoomModel model);

        /// <summary>
        /// Filters the rooms by campus, building and floor.
        /// </summary>
        /// <param name="campus">The name of the campus. If null, the rooms for all existing campuses are returned.</param>
        /// <param name="buildingName">The name of the building. If null, the rooms of all building in the campus are returned.</param>
        /// <param name="floor">The number of the floor. If null, the rooms in the whole building are returned.</param>
        public IQueryable<RoomDto> FilterRooms(string? campus, string? buildingName, int? floor);
    }
}
