using Froom.Data.Models.Users;
using Froom.Data.Repositories.Interfaces;
using System;
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

        public Task AddUserAsync(PostUserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
