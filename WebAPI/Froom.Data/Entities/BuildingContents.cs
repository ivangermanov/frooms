using System.Collections.Generic;

namespace Froom.Data.Entities
{
    public class BuildingContents
    {
        public int Id { get; set; }

        public string BuildingName { get; set; }

        public Building Building { get; set; }

        public string FloorNumber { get; set; }

        public Floor Floor { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
