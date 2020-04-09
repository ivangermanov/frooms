using Froom.Data.Models.Users;
using Microsoft.AspNetCore.Mvc;
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
    }
}