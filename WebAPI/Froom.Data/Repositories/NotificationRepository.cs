using System;
using System.Linq;
using System.Threading.Tasks;
using Froom.Data.Database;
using Froom.Data.Entities;
using Froom.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Froom.Data.Repositories
{
    /// <inheritdoc cref="INotificationRepository"/>
    public class NotificationRepository : INotificationRepository
    {
        private readonly FroomContext _context;
        private readonly DbSet<Notification> _notifications;

        public NotificationRepository(FroomContext context)
        {
            _context = context ?? throw new ArgumentException($"{nameof(FroomContext)} is null.");
            _notifications = _context.Set<Notification>();
        }

        public async Task AddAsync(Notification notification)
        {
            await _context.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Notification> GetForUser(Guid userId)
        {
            return _notifications
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedDate);
        }

        public async Task MarkReadAsync(int notificationId)
        {
            var notification = await _notifications.FindAsync(notificationId);
            notification.IsNew = false;

            await _context.SaveChangesAsync();
        }
    }
}
