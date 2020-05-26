using System;

namespace Froom.Data.Entities
{
    public class Notification
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool? IsNew { get; set; }
    }
}
