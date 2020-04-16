using Froom.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Froom.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Adds a user to the database context.
        /// </summary>
        /// <param name="user"> The user to be added.</param>
        Task AddAsync(User user);

        /// <summary>
        /// Gets all users from the database context.
        /// </summary>
        IQueryable<User> GetAll();

        /// <summary>
        /// Gets a user by id from the database context.
        /// </summary>
        /// <param name="id"> The id of the user.</param>
        Task<User> GetByNumberAsync(string Id);

        /// <summary>
        /// Updates information about a user.
        /// </summary>
        /// <param name="user"> The user to be updated.</param>
        Task Update(User user);
    }
}
