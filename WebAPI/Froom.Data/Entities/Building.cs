using System.Collections.Generic;

namespace Froom.Data.Entities
{
    public class Building
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string CampusName { get; set; }

        public Campus Campus { get; set; }

        public ICollection<BuildingContents> Contents { get; set; }
    }
}
