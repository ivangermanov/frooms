using System.Collections.Generic;

namespace Froom.Data.Entities
{
    public class Building
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CampusId { get; set; }

        public Campus Campus { get; set; }

        public string Address { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
