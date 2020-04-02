using System.Collections.Generic;
using Froom.Data.Dtos;
using Froom.Data.Models.Rooms;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public interface IRoomService
    {
        /// <summary>
        /// Adds multiple new rooms.
        /// </summary>
        /// <param name="models">The rooms to be added.</param>
        public Task AddRangeAsync(IEnumerable<PostRoomModel> models);

        /// <summary>
        /// Filters the rooms by campus, building and floor.
        /// </summary>
        /// <param name="campus">The name of the campus.</param>
        /// <param name="buildingName">The name of the building.</param>
        /// <param name="floor">The number of the floor. If null, the rooms for the whole building are returned.</param>
        public IQueryable<RoomDto> GetRooms(string campus, string buildingName, int? floor);

        /// <summary>
        /// Returns the rooms without reservations for a period of time.
        /// </summary>
        /// <param name="campus">The name of the campus.</param>
        /// <param name="buildingName">The name of the building.</param>
        /// <param name="floor">The number of the floor.</param>
        /// <param name="fromDate">The start time of the period.</param>
        /// <param name="toDate">The end time of the period.</param>
        /// <returns></returns>
        public IQueryable<RoomDto> GetAvailableRooms(string campus, string buildingName, int floor, DateTime fromDate, DateTime toDate);
    }
}
