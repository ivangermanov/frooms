using System;

namespace Froom.Data.Dtos
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }

        public RoomDto Room { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Expired { get; set; }
        public bool IsCancelled { get; set; }

        /// <summary>
        /// Used only by IMapper. Initializes a new instance of ReservationDto.
        /// </summary>
        public ReservationDto() { }
    }
}
