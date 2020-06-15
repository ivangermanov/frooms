using System.Collections.Generic;
using Froom.Data.Entities;

namespace Froom.Data.Dtos
{
    public class FloorMapRoomDto
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public string BuildingName { get; set; }

        public string CampusName { get; set; }

        public string FloorNumber { get; set; }

        public int FloorOrder { get; set; }

        public int? Capacity { get; set; }

        public ICollection<Point> Points { get; set; }

        public bool IsAvailable { get; set; }
    }
}