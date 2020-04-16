using System;
using System.Collections.Generic;

namespace Froom.Data.Entities
{
    public class Report
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public Room Room { get; set; }

        public int RoomId { get; set; }

        public DateTime DateCreated { get; set; }

        public string Description { get; set; }

        public ICollection<Picture> Pictures { get; set; }
    }
}
