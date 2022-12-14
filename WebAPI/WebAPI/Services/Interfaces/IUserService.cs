using Froom.Data.Dtos;
using Froom.Data.Entities;
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
        public Task<UserDto> AddUserAsync(PostUserModel model);

        /// <summary>
        /// Gets a user based on specified ID.
        /// Returns null if user does not exist.
        /// </summary>
        public Task<UserDto> GetUserByIdAsync(Guid id);

        /// <summary>
        /// Gets all users.
        /// </summary>
        public Task<IEnumerable<UserDto>> GetAllUsersAsync();

        /// <summary>
        /// Blocks the user.
        /// </summary>
        public Task<UserDto> BlockUserAsync(Guid id);

        /// <summary>
        /// Unblocks the user.
        /// </summary>
        public Task<UserDto> UnblockUserAsync(Guid id);

        /// <summary>
        /// Changes the role of the user.
        /// </summary>
        public Task<UserDto> ChangeRoleAsync(Guid id, UserRole role);

        /// <summary>
        /// Check if a user exist.
        /// If the user does not exist, create it.
        /// </summary>
        public Task<UserDto> FindOrCreateUserAsync(PostUserModel model);

        /// <summary>
        /// Gets all notifications for a user.
        /// </summary>
        public Task<IEnumerable<NotificationDto>> GetNotificationsAsync(Guid userId);

        /// <summary>
        /// Marks a notification as not new.
        /// </summary>
        public Task MarkNotificationRead(int notificationId);

        /// <summary>
        /// Marks all current notifications as not new.
        /// </summary>
        public Task MarkNotificationsRead(Guid userId);
    }
}
