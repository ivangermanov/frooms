using AutoMapper;
using Froom.Data.Entities;
using Froom.Data.Models.Users;
using Froom.Data.Repositories.Interfaces;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    /// <inheritdoc cref="IUserService"/>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task AddUserAsync(PostUserModel model)
        {
            var user = _mapper.Map<User>(model);

            await _userRepository.AddAsync(user);
        }
    }
}
