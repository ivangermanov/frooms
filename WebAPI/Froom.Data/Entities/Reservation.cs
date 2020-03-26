using System;

namespace Froom.Data.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime Duration { get; set; }
    }
}
