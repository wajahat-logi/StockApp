using JWTToken.Model;
using JWTToken.Model.Authentication.SignUp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JWTToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthenticationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser register, string role)
        {
            IdentityUser userExist = await _userManager.FindByEmailAsync(register.Email);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "User already Exist!" });
            }

            IdentityUser user = new() { Email = register.Email, SecurityStamp= Guid.NewGuid().ToString(), UserName=register.UserName };

            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, role);
                    return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = "User is created" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Failed to Create" });
                }
            }else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "This Role is not Existed" });
            }



        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(RegisterUser register, string rol)
        {
            return Ok(2);
        }
    }
}
