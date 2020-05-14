using AutoMapper;
using Froom.Data.Dtos;
using Froom.Data.Entities;
using Froom.Data.Exceptions;
using Froom.Data.Models.Users;
using Froom.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<UserDto> AddUserAsync(PostUserModel model)
        {
            var user = _mapper.Map<User>(model);

            await _userRepository.AddAsync(user);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> FindOrCreateUserAsync(PostUserModel model)
        {
            var user = (await GetUserAsync(model.Id)).FirstOrDefault();
            if(user == null)
            {
                user = await AddUserAsync(model);
            }

            return user;
        }

        public async Task<IEnumerable<UserDto>> GetUserAsync(Guid? id, string? name = null)
        {
            var users = _userRepository.GetAll()
                .Where(e => id == null || e.Id.Equals(id))
                .Where(e => string.IsNullOrEmpty(name) || e.Name.Equals(name));

            return await _mapper.ProjectTo<UserDto>(users).ToListAsync();
        }
    }
}
