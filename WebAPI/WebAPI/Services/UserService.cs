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
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
            INotificationRepository notificationRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> AddUserAsync(PostUserModel model)
        {
            var user = _mapper.Map<User>(model);

            await _userRepository.AddAsync(user);

            var notification = new Notification()
            {
                UserId = user.Id,
                Title = "Welcome to Frooms!",
                Message = "You just made your first reservation. :)"
            };

            await _notificationRepository.AddAsync(notification);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> FindOrCreateUserAsync(PostUserModel model)
        {
            var user = await GetUserByIdAsync(model.Id);

            if (user is null)
                user = await AddUserAsync(model);

            return user;
        }

        public async Task<IEnumerable<NotificationDto>> GetNotificationsAsync(Guid userId)
        {
            var user = await GetUserByIdAsync(userId);

            if (user is null)
                return new List<NotificationDto>();

            var notifications = _notificationRepository.GetForUser(userId);

            return await _mapper.ProjectTo<NotificationDto>(notifications).ToListAsync();
        }

        public async Task MarkNotificationRead(int notificationId)
        {
            await _notificationRepository.MarkReadAsync(notificationId);
        }

        public async Task MarkNotificationsRead(Guid userId)
        {
            await _notificationRepository.MarkReadForUserAsync(userId);
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                return _mapper.Map<UserDto>(user);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = _userRepository.GetAll();
            return await _mapper.ProjectTo<UserDto>(users).ToListAsync();
        }

        public async Task<UserDto> ChangeRoleAsync(Guid id, UserRole role)
        {
            var user = await _userRepository.GetByIdAsync(id);
            user.Role = role;
            await _userRepository.Update(user);

            if(user.Role == UserRole.ADMIN)
            {
                var notification = new Notification()
                {
                    UserId = user.Id,
                    Title = "Role changed",
                    Message = "You are now an admin."
                };

                await _notificationRepository.AddAsync(notification);
            }


            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> BlockUserAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if(user.Role != UserRole.ADMIN)
            {
                user.IsBlocked = true;
                await _userRepository.Update(user);

                var notification = new Notification()
                {
                    UserId = user.Id,
                    Title = "Profile blocked",
                    Message = "You are now blocked. " +
                    "Contact the administration for more information."
                };

                await _notificationRepository.AddAsync(notification);
            }

            return _mapper.Map<UserDto>(user);
        }
        

        public async Task<UserDto> UnblockUserAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            user.IsBlocked = false;
            await _userRepository.Update(user);

            var notification = new Notification()
            {
                UserId = user.Id,
                Title = "Profile unblocked",
                Message = "Your profile is unblocked. " +
                "You can make reservations."
            };

            await _notificationRepository.AddAsync(notification);


            return _mapper.Map<UserDto>(user);
        }
    }
}
