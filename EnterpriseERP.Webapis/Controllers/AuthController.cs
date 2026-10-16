using EnterpriseERP.Insfrastructure.Identity;
using EnterpriseERP.Insfrastructure.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace EnterpriseERP.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly JwtService _jwtService;
        public AuthController(UserManager<AppUser> UserManager, SignInManager<AppUser> SignInManager,
            JwtService jwtService)
        {
            _userManager = UserManager;
            _signInManager = SignInManager;
            _jwtService = jwtService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string email, string password)
        {
            var user = new AppUser
            {
                UserName = username,
                Email = email
            };
            var res = await _userManager.CreateAsync(user, password);
            if (!res.Succeeded)
            {
                return BadRequest(res.Errors);
            }
            return Ok();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
           {
                return Unauthorized("Invalid Email and password");
           }
            var result = await _signInManager.CheckPasswordSignInAsync(user, password,false);
            if (!result.Succeeded)
                return BadRequest("Invalid email or password");
            var token = _jwtService.GenerateToken(user);
            return Ok(new
            {
                message = "Login Successfull",
                token = token
            });
        }
    }
}
