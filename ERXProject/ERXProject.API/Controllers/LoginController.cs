using ERXProject.Core.Users;
using ERXProject.Services.AuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERXProject.API.Controllers
{
    [Route("/login")]
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginParams loginParams)
        {
            var result = await _authService.LoginAsync(loginParams);

            if (result == null) { return BadRequest(); }

            return Ok(result);
        }
    }
}
