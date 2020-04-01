using Froom.Data.Entities;

namespace Froom.Data.Dtos
{
    public class UserDto
    {
        public int Number { get; set; }

        public string Name { get; set; }

        public UserRole Role { get; set; }

        public UserDto(User user)
        {
            Number = user.Number;
            Name = user.Name;
            Role = user.Role;
        }
    }
}
