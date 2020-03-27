using Froom.Data.Entities;
using System.Collections.Generic;

namespace Froom.Data.Models
{
    public class PostRoomModel
    {
        public string Number { get; set; }
        public int Floor { get; set; }
        public string BuildingName { get; set; }
        public int Capacity { get; set; }
        public ICollection<Point> Points { get; set; }
    }
}
