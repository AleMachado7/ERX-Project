using ERXProject.Core.Users;
using ERXProject.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERXProject.API.Controllers
{
    [Route("/sign-up")]
    public class SignUpController : Controller
    {
        private readonly IUserService _userService;

        public SignUpController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] UserParams createParams)
        {
            var user = await _userService.CreateAsync(createParams);

            if (user == null) { return BadRequest(); }

            return Ok(user);
        }
    }
}
