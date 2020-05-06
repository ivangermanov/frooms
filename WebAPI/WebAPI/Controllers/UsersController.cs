using Froom.Data.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Helpers;
using WebAPI.Services.Interfaces;

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

        [HttpGet]
        public async Task<IActionResult> GetUser(string name)
        {
            var user = await _userService.GetUserByNameOrCreateAsync(name);
            return Ok(user);
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
    }
}