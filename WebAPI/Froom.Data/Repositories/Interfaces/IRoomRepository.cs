using Froom.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Froom.Data.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        /// <summary>
        /// Adds a room to the database context.
        /// </summary>
        /// <param name="room"> The room to be added.</param>
        Task AddAsync(Room room);

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
        Task Update(Room room);

        /// <summary>
        /// Updates information about a room.
        /// </summary>
        /// <param name="room"> The room to be updated.</param>
        Task RemoveAsync(Room room);
    }
}
