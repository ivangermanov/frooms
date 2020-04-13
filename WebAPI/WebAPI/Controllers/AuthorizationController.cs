using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly FontysAPI _fontysApi;

        public AuthorizationController(FontysAPI fontysApi)
        {
            _fontysApi = fontysApi;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            var result = await _fontysApi.GetUserInfo();
            return Ok(result);
        }
    }
}