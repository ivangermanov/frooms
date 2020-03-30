using System.Collections.Generic;
using Froom.Data.Entities;

namespace Froom.Data.Models
{
    public class RoomModel
    {
        public int Number { get; set; }
        public int Floor { get; set; }
        public string BuildingName { get; set; }
        public int Capacity { get; set; }
        public ICollection<Point> Points { get; set; }
    }
}