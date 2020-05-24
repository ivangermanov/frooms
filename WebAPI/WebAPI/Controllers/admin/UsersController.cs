using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Froom.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers.admin
{
    [Route("api/admin/users")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetUserAsync();
            return Ok(result.ToList());
        }

        [HttpPost]
        [Route("{userId}/block")]
        public async Task<IActionResult> BlockUser(Guid userId)
        {
            var user = await _userService.BlockUserAsync(userId);
            return Ok(user);
        }

        [HttpPost]
        [Route("{userId}/unblock")]
        public async Task<IActionResult> UnblockUser(Guid userId)
        {
            var user = await _userService.UnblockUserAsync(userId);
            return Ok(user);
        }
    }
}