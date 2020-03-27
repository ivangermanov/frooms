using System.Collections.Generic;

namespace Froom.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }
        
        public string Number { get; set; }

        public int Floor { get; set; }

        public string BuildingName { get; set; }

        public Building Building { get; set; }

        public int Capacity { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

        public ICollection<Point> Points { get; set; }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}