using Froom.Data.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult AddUser(PostUserModel model)
        {
            return Ok(_userService.AddUserAsync(model));
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