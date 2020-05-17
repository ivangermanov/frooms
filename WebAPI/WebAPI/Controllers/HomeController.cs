using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [Route("logout")]
        [HttpGet]
        public ActionResult Logout()
        {
            return SignOut(CookieAuthenticationDefaults.AuthenticationScheme,
                OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}