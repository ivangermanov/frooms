using System;

namespace Froom.Data.Models.Notifications
{
    public class PostNotificationModel
    {
        public Guid UserId { get; set; }

        public string Message { get; set; }
    }
}
