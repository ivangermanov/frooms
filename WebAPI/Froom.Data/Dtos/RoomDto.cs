using Froom.Data.Entities;
using System.Collections.Generic;

namespace Froom.Data.Dtos
{
    public class RoomDto
    {
        public string Number { get; set; }
        public int Floor { get; set; }
        public string BuildingName { get; set; }
        public string CampusName { get; set; }
        public int Capacity { get; set; }
        public ICollection<Point> Points { get; set; }

        public RoomDto(Room room, string campus)
        {
            Number = room.Number;
            Floor = room.Floor;
            BuildingName = room.BuildingName;
            CampusName = campus;
            Capacity = room.Capacity;
            Points = room.Points;
        }
    }
}
