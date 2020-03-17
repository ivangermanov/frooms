using System;
using System.Collections.Generic;

namespace Froom.Data.Models
{
    public enum Role
    {
        Student = 1,
        Teacher = 2,
        Admin = 3
    }
    public class User
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}