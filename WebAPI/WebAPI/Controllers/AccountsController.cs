using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    public class AccountsController : ControllerBase
    {
        [Route("login")]
        public async Task Login(string? returnUrl = "/")
        {
            await HttpContext.ChallengeAsync(new AuthenticationProperties {RedirectUri = returnUrl});
        }

        [Route("logout")]
        public ActionResult Logout()
        {
            return SignOut(CookieAuthenticationDefaults.AuthenticationScheme,
                OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}