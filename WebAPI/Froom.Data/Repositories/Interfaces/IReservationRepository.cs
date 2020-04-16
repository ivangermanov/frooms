using Froom.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Froom.Data.Repositories.Interfaces
{
    public interface IReservationRepository
    {
        /// <summary>
        /// Adds a reservation to the database context.
        /// </summary>
        /// <param name="reservation"> The reservation to be added.</param>
        Task AddAsync(Reservation reservation);

        /// <summary>
        /// Gets all reservations from the database context.
        /// </summary>
        IQueryable<Reservation> GetAll();

        /// <summary>
        /// Gets a reservation by id from the database context.
        /// </summary>
        /// <param name="id"> The id of the reservation.</param>
        Task<Reservation> GetByIdAsync(int id);

        /// <summary>
        /// Gets all reservations for a specific user.
        /// </summary>
        /// <param name="userId"> The unique number of the user.</param>
        IQueryable<Reservation> GetForUser(string userId);

        /// <summary>
        /// Updates information about a reservation.
        /// </summary>
        /// <param name="reservation"> The reservation to be updated.</param>
        Task UpdateAsync(Reservation reservation);

        /// <summary>
        /// Updates information about a reservation.
        /// </summary>
        /// <param name="reservation"> The reservation to be updated.</param>
        Task RemoveAsync(Reservation reservation);
    }
}
