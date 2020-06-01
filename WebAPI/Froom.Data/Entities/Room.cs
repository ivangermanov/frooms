using System;
using System.Collections.Generic;
using System.Linq;

namespace Froom.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public int DetailsId { get; set; }

        public BuildingContents Details { get; set; }

        public int? Capacity { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

        public ICollection<Point> Points { get; set; }

        public bool IsAvailable(DateTime? fromDate, DateTime? toDate)
        {
            if (Reservations is null || Reservations.Count == 0)
                return true;

            return !Reservations
                .Any(r => DateTime.Compare(r.StartDate, toDate ?? DateTime.MaxValue) < 0 &&
                          DateTime.Compare(fromDate ?? DateTime.MinValue, r.EndDate) < 0);
        }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}