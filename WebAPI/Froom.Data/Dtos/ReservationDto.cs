using Froom.Data.Entities;
using System;

namespace Froom.Data.Dtos
{
    public class ReservationDto
    {
        public UserDto User { get; set; }

        public RoomDto Room { get; set; }

        public DateTime StartTime { get; set; }

        public TimeSpan Duration { get; set; }

        public ReservationDto(Reservation reservation)
        {
            User = new UserDto(reservation.User);
            Room = new RoomDto(reservation.Room);
            StartTime = reservation.StartTime;
            Duration = reservation.Duration;
        }
    }
}
