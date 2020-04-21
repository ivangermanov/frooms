using System.Collections.Generic;

namespace Froom.Data.Dtos
{
    public class BuildingDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string CampusName { get; set; }

        public IEnumerable<BuildingContentsDto> Contents { get; set; }

        /// <summary>
        /// Used only by IMapper. Initializes a new instance of BuildingDto.
        /// </summary>
        public BuildingDto() { }
    }
}
