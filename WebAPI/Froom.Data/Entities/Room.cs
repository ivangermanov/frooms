using System.Collections.Generic;

namespace Froom.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }
        // TODO: This should be a string
        public int Number { get; set; }

        public int Floor { get; set; }

        public int BuildingId { get; set; }

        public Building Building { get; set; }

        public int Capacity { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

        public ICollection<Point> Points { get; set; }

        public Shape Shape { get; set; }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public enum Shape
    {
        RECTANGLE = 0,
        CIRCLE = 1,
        POLYGON = 2
    }
}