using FrontEnd.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReactApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly CookieSetting cookieSetting;

        public AuthController(CookieSetting cookieSetting)
        {
            this.cookieSetting = cookieSetting;
        }

        [HttpGet("login")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(OpenIdConnectDefaults.AuthenticationScheme);
            }

            return Redirect("/");
        }

        [HttpGet("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            var authenProperties = new AuthenticationProperties
            {
                RedirectUri = "/",
                AllowRefresh = true,
                IsPersistent = true
            };

            return SignOut(
                authenProperties,
                cookieSetting.CookieName,
                OpenIdConnectDefaults.AuthenticationScheme);
        }

        [HttpGet("getusername")]
        [Authorize]
        public IActionResult GetUserName()
        {
            var username = User.FindFirst(c => c.Type == "name")?.Value;
            return new JsonResult(username);
        }
    }
}