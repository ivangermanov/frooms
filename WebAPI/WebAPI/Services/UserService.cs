using Froom.Data.Entities;
using Froom.Data.Models.Users;
using Froom.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    /// <inheritdoc cref="IUserService"/>
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUserAsync(PostUserModel model)
        {
            var user = new User()
            {
                Name = model.Name,
                Role = model.Role,
                Number = model.Number,
                Reservations = new List<Reservation>()
            };

            await _userRepository.AddAsync(user);
        }
    }
}
