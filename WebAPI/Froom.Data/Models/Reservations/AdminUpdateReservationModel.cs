using System;

namespace Froom.Data.Models.Reservations
{
    public class AdminUpdateReservationModel
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public int RoomId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
