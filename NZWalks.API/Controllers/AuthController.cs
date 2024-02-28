using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        // POST: /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser()
            {
                UserName = registerRequestDTO.Username,
                Email = registerRequestDTO.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDTO.Password);

            if (identityResult.Succeeded)
            {
                // Add roles to this user

                if(registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {
                    await userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);

                    if(identityResult.Succeeded)
                    {
                        return Ok("User was register");
                    }
                }
            }

            return BadRequest("Something went wrong");
        }

        // POST /api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDTO.Username);

            if(user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

                if(checkPasswordResult)
                {
                    // Get roles fro this user
                    var roles = await userManager.GetRolesAsync(user);

                    if(roles != null && roles.Any())
                    {
                        //Create Token
                        var token = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDTO()
                        {
                            JwtToken = token,
                        };

                        return Ok(response);
                    }


                }
            }

            return BadRequest("User or Password incorrect");
        }
    }
}
