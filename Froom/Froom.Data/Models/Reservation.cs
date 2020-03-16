using System;
using System.Collections.Generic;

namespace Froom.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RoomName { get; set; }
        public virtual User User { get; set; }
    }
}
