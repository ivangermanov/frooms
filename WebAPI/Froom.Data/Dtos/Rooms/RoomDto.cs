using System;
using System.Collections.Generic;
using System.Text;
using Froom.Data.Entities;

namespace Froom.Data.Dtos.Rooms
{
    public class RoomDto
    {
        public int Number { get; set; }
        public int Floor { get; set; }
        public Building Building { get; set; }
        public int Capacity { get; set; }
        public ICollection<Point> Points { get; set; }
        public Shape Shape { get; set; }
    }
}
