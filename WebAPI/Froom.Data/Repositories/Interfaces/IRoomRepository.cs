using System.Collections.Generic;
using Froom.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Froom.Data.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        /// <summary>
        /// Adds a collection of rooms to the database context.
        /// </summary>
        /// <param name="rooms"> The rooms  to be added.</param>
        public Task AddRangeAsync(IEnumerable<Room> rooms);

        /// <summary>
        /// Gets all rooms from the database context.
        /// </summary>
        IQueryable<Room> GetAll();

        /// <summary>
        /// Gets a room by id from the database context.
        /// </summary>
        /// <param name="id"> The id of the room.</param>
        Task<Room> GetByIdAsync(int id);

        /// <summary>
        /// Updates information about a room.
        /// </summary>
        /// <param name="room"> The room to be updated.</param>
        Task UpdateAsync(Room room);

        /// <summary>
        /// Updates information about a room.
        /// </summary>
        /// <param name="room"> The room to be updated.</param>
        Task RemoveAsync(Room room);
    }
}
