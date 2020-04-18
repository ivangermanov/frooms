using System;
using System.Collections.Generic;
using System.Linq;

namespace Froom.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }
        
        public string Number { get; set; }

        public string Floor { get; set; }

        public string BuildingName { get; set; }

        public string BuildingCampus { get; set; }

        public Building Building { get; set; }

        public int? Capacity { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

        public ICollection<Point> Points { get; set; }

        public bool IsAvailable(DateTime fromDate, DateTime toDate)
        {
            if (this.Reservations is null)
                return true;

            return this.Reservations
                .Where(r => r.StartTime.Add(r.Duration) <= fromDate && r.StartTime >= toDate)
                .Any();
        }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}