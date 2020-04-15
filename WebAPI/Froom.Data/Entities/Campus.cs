using System.Collections.Generic;

namespace Froom.Data.Entities
{
    public class Campus
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Building> Buildings { get; set; }
    }
}
