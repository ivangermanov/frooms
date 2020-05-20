﻿using Froom.Data.Dtos;
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
        /// Gets a user based on specified number or name.
        /// If nothing is pecified returns all users.
        /// </summary>
        public Task<IEnumerable<UserDto>> GetUserAsync(Guid? id=null, string? name=null);

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
    }
}
