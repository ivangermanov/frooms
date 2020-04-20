using Froom.Data.Dtos;
using Froom.Data.Models.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Adds a user.
        /// </summary>
        public Task AddUserAsync(PostUserModel model);
        /// <summary>
        /// Gets a user based on specified number or name.
        /// If nothing is pecified returns all users.
        /// </summary>
        public Task<IEnumerable<UserDto>> GetUserAsync(Guid? id, string? name);
    }
}
