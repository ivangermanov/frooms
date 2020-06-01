using Froom.Data.Dtos;
using Froom.Data.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public interface IRoomService
    {
        /// <summary>
        /// Filters the rooms by campus, building and floor.
        /// </summary>
        /// <param name="campus">The name of the campus.</param>
        /// <param name="building">The name of the building.</param>
        /// <param name="floor">The number of the floor. If null, the rooms for the whole building are returned.</param>
        public Task<IEnumerable<FloorMapRoomDTO>> GetFloormapRooms(string? campus, string? building, string? floor, DateTime? fromDate,
        DateTime? toDate);

        /// <summary>
        /// Returns the rooms without reservations for a period of time.
        /// </summary>
        /// <param name="campus">The name of the campus.</param>
        /// <param name="building">The name of the building.</param>
        /// <param name="floor">The number of the floor.</param>
        /// <param name="fromDate">The start time of the period.</param>
        /// <param name="toDate">The end time of the period.</param>
        /// <returns></returns>
        public Task<IEnumerable<RoomDto>> GetAvailableRooms(string campus, string building, string floor, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Adds multiple new rooms.
        /// </summary>
        /// <param name="model">The rooms to be added.</param>
        public Task AddRangeAsync(IEnumerable<PostRoomModel> model);

        /// <summary>
        /// Updates multiple rooms.
        /// </summary>
        /// <param name="model">The rooms to be added.</param>
        public Task UpdateRangeAsync(IEnumerable<PostRoomModel> model);

        /// <summary>
        /// Deletes multiple rooms.
        /// </summary>
        /// <param name="model">The rooms to be deleted.</param>
        public Task RemoveRangeAsync(IEnumerable<DeleteRoomModel> model);
    }
}
