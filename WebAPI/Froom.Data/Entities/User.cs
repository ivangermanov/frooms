using System;
using System.Collections.Generic;

namespace Froom.Data.Entities
{
    public class User
    {
        public int Number { get; set; }

        public string Name { get; set; }

        public UserRole Role { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }

    public enum UserRole
    {
        NORMAL = 0,
        ADMIN = 1
    }
}
