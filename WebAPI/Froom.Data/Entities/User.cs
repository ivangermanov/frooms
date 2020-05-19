using System;
using System.Collections.Generic;

namespace Froom.Data.Entities
{
    public class User
    {
        public User()
        {
            Role = UserRole.USER;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool IsBlocked { get; set; }
        public UserRole Role { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }

    public enum UserRole
    {
        USER = 0,
        ADMIN = 1
    }
}
