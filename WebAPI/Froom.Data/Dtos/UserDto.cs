using Froom.Data.Entities;
using System;

namespace Froom.Data.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public UserRole Role { get; set; }

        /// <summary>
        /// Used only by IMapper. Initializes a new instance of UserDto.
        /// </summary>
        public UserDto() { }
    }
}
