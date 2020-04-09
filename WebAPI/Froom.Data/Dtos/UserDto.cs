using Froom.Data.Entities;

namespace Froom.Data.Dtos
{
    public class UserDto
    {
        public int Number { get; set; }

        public string Name { get; set; }

        public UserRole Role { get; set; }

        /// <summary>
        /// Used only by IMapper. Initializes a new instance of UserDto.
        /// </summary>
        public UserDto() { }
    }
}
