using Froom.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Froom.Data.Models.Users
{
    public class PostUserModel
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
