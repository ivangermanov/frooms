using System;

namespace Froom.Data.Models.Reservations
{
    public class PostReservationModel
    {
        public int UserNumber { get; set; }

        public int RoomId { get; set; }

        public DateTime StartTime { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
