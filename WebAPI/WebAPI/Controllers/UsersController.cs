using Froom.Data.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using WebAPI.Helpers;
using WebAPI.Services.Interfaces;
using System;

namespace WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService; 
        private readonly FontysAPI _fontysApi;

        public UsersController(IUserService userService, FontysAPI fontysApi)
        {
            _fontysApi = fontysApi;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(PostUserModel model)
        {
            await _userService.AddUserAsync(model);
            return Ok();
        }

        [HttpPost]
        [Route("findorcreate")]
        public async Task<IActionResult> FindOrCreateUser(PostUserModel model)
        {
            var result = await _userService.FindOrCreateUserAsync(model);
            return Ok(result);
        }

        [HttpGet]
        [Route("me")]
        public async Task<IActionResult> GetUserInfo()
        {
            var result = await _fontysApi.GetUserInfo();
            return Ok(result);
        }

        [Route("me/roles")]
        [HttpGet]
        public IActionResult GetUserRoles()
        {
            var roles = User.Claims.Where(e => e.Type == ClaimTypes.Role).Select(role => role.Value).ToList();
            return Ok(roles);
        }

        [Route("me/blocked")]
        [HttpGet]
        public async Task<IActionResult> CheckIfBlocked()
        {
            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var user = await _userService.GetUserByIdAsync(userId);

            if (user is null || !user.IsBlocked)
                return Ok(false);

            return Ok(true);
        }

        [Route("me/notifications")]
        [HttpGet]
        public async Task<IActionResult> GetUserNotifications()
        {
            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var notifications = await _userService.GetNotificationsAsync(userId);

            return Ok(notifications);
        }

        [Route("me/notifications/{notificationId}")]
        [HttpPost]
        public async Task<IActionResult> MarkNotificationRead(int notificationId)
        {
            await _userService.MarkNotificationRead(notificationId);
            return Ok();
        }

        [Route("me/notifications")]
        [HttpPost]
        public async Task<IActionResult> MarkNotificationsRead()
        {
            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _userService.MarkNotificationsRead(userId);
            return Ok();
        }
    }
}