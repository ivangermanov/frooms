using System.Collections.Generic;
using Froom.Data.Entities;
using System.Linq;
using System.Threading.Tasks;
using Froom.Data.Models.Rooms;

namespace Froom.Data.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        /// <summary>
        /// Adds a room to the database context.
        /// </summary>
        /// <param name="room"> The room to be added.</param>
        public Task AddAsync(Room room);

        /// <summary>
        /// Adds a collection of rooms to the database context.
        /// </summary>
        /// <param name="rooms"> The rooms  to be added.</param>
        public Task AddRangeAsync(IEnumerable<Room> rooms);

        /// <summary>
        /// Updates a collection of rooms to the database context.
        /// </summary>
        /// <param name="rooms"> The rooms  to be added.</param>
        public Task UpdateRangeAsync(IEnumerable<Room> rooms);

        /// <summary>
        /// Removes a collection of rooms from the database context.
        /// </summary>
        /// <param name="rooms"> The rooms  to be deleted.</param>
        public Task RemoveRangeAsync(IEnumerable<Room> rooms);

        /// <summary>
        /// Gets all rooms from the database context.
        /// </summary>
        public IQueryable<Room> GetAll();

        /// <summary>
        /// Gets a room by id from the database context.
        /// </summary>
        /// <param name="id"> The id of the room.</param>
        public Task<Room> GetByIdAsync(int id);

        /// <summary>
        /// Gets the full database entitity.
        /// </summary>
        /// <param name="room"> The room.</param>
        public Task<Room> GetEntityAsync(Room room);

        /// <summary>
        /// Updates information about a room.
        /// </summary>
        /// <param name="room"> The room to be updated.</param>
        public Task UpdateAsync(Room room);

        /// <summary>
        /// Updates information about a room.
        /// </summary>
        /// <param name="room"> The room to be updated.</param>
        public Task RemoveAsync(Room room);
    }
}
