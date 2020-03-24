using System.Collections.Generic;

namespace Froom.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int Floor { get; set; }

        public int BuildingId { get; set; }

        public Building Building { get; set; }

        public int Capacity { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

        public MapDetails MapDetails { get; set; }
    }
}
