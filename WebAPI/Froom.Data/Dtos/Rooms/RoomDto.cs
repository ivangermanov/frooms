using System;
using System.Collections.Generic;
using System.Text;
using Froom.Data.Entities;

namespace Froom.Data.Dtos.Rooms
{
    public class RoomDto
    {
        public string Number { get; set; }
        public int Floor { get; set; }
        public string BuildingName { get; set; }
        public string CampusName { get; set; }
        public int Capacity { get; set; }
        public ICollection<Point> Points { get; set; }

        public RoomDto(Room room, FontysCampus campus)
        {
            Number = room.Number;
            Floor = room.Floor;
            BuildingName = room.BuildingName;
            CampusName = campus.ToString();
            Capacity = room.Capacity;
            Points = room.Points;
        }
    }
}
