using Froom.Data.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult AddUser(PostUserModel model)
        {
            return Ok(_userService.AddUserAsync(model));
        }


        [Route("getUserRoles")]
        [HttpGet]
        [Authorize]
        public IActionResult GetCurrentUserRoles()
        {
            var roles = User.Claims.Where(e => e.Type == ClaimTypes.Role).ToList();
            return Ok(roles);
        }
    }
}