using System;

namespace Froom.Data.Dtos
{
    public class ReservationDto
    {
        public UserDto User { get; set; }

        public RoomDto Room { get; set; }

        public DateTime StartTime { get; set; }

        public TimeSpan Duration { get; set; }

        public bool Expired { get; set; }

        /// <summary>
        /// Used only by IMapper. Initializes a new instance of ReservationDto.
        /// </summary>
        public ReservationDto() { }
    }
}
