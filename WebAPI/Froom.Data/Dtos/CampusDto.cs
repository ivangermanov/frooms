using Froom.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Froom.Data.Dtos
{
    public class CampusDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<BuildingDto> Buildings { get; set; }

        /// <summary>
        /// Used only by IMapper. Initializes a new instance of BuildingDto.
        /// </summary>
        public CampusDto() { }
    }
}
