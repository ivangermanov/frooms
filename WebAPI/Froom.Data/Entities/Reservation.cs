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

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsCancelled { get; set; }

        public bool IsExpired() => DateTime.Compare(this.EndDate, DateTime.Now) <= 0;
    }
}
