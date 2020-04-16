using Froom.Data.Entities;

namespace Froom.Data.Models.Users
{
    public class PostUserModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
    }
}
