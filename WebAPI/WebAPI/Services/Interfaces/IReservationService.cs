using Froom.Data.Dtos;
using Froom.Data.Models.Reservations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public interface IReservationService
    {
        /// <summary>
        /// Adds a new reservation.
        /// </summary>
        /// <param name="model">The reservation to be added.</param>
        public Task AddReservationAsync(PostReservationModel model);

        /// <summary>
        /// Retrieves the reservations for specific room.
        /// </summary>
        /// <param name="roomId">The ID of the room.</param>
        public IQueryable<ReservationDto> GetReservationsForRoom(int roomId);

        /// <summary>
        /// Retrieves the reservations for specific user.
        /// </summary>
        /// <param name="userId">The unique number of the user.</param>
        /// <returns></returns>
        public IQueryable<ReservationDto> GetReservationsForUser(int userNumber);
    }
}
