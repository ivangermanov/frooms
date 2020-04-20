using System;

namespace Froom.Data.Models.Reservations
{
    public class PostReservationModel
    {
        public string UserId { get; set; }

        public int RoomId { get; set; }

        public DateTime StartTime { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
