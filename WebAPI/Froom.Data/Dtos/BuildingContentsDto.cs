using System.Collections.Generic;

namespace Froom.Data.Dtos
{
    public class BuildingContentsDto
    {
        public string FloorNumber { get; set; }

        public int FloorOrder { get; set; }

        public ICollection<RoomDto> Rooms { get; set; }
    }
}
