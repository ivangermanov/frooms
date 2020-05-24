using System;
using System.Linq;
using System.Threading.Tasks;
using Froom.Data.Entities;

namespace Froom.Data.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        /// <summary>
        /// Adds a notification for a user.
        /// </summary>
        /// <param name="notification"> The notification to be added.</param>
        Task AddAsync(Notification notification);

        /// <summary>
        /// Gets all notifications for a user, sorted by descending date.
        /// </summary>
        /// <param name="userId"> The ID of the user.</param>
        IQueryable<Notification> GetForUser(Guid userId);

        /// <summary>
        /// Marks a notification as not new.
        /// </summary>
        /// <param name="notificationId"> The ID of the notification.</param>
        public Task MarkReadAsync(int notificationId);
    }
}
