using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes ="Bearer")]
    [Authorize(AuthenticationSchemes = "Bearer,Cookies")]
    [Route("api/[controller]")]
    public class AccountController:ControllerBase
    {
        [HttpPost("Register")]
        public IActionResult Register()
        {
            return Ok("Registered");
        }

        [HttpPost("Login")]
        public IActionResult Login()
        {
            return Ok("Login");
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            return Ok("Logout");
        }
    }
}