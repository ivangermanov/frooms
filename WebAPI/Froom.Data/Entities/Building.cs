using System.Collections.Generic;

namespace Froom.Data.Entities
{
    public class Building
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public FontysCampus Campus { get; set; }

        public string Address { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }

    // TODO: Ivan - I think it's better to keep this as string
    public enum FontysCampus
    {
        EINDHOVEN = 0,
        TILBURG = 1,
        VENLO = 2
    }
}
