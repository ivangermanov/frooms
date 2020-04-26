using Froom.Data.Entities;
using System.Collections.Generic;

namespace Froom.Data.Dtos
{
    public class RoomDto
    {
        public string Number { get; set; }

        public string BuildingName { get; set; }

        public string CampusName { get; set; }

        public string FloorNumber { get; set; }

        public int FloorOrder { get; set; }

        public int? Capacity { get; set; }

        public ICollection<Point> Points { get; set; }

        /// <summary>
        /// Used only by IMapper. Initializes a new instance of RoomDto.
        /// </summary>
        public RoomDto() { }
    }
}
