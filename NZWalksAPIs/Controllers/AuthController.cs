using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPIs.Model.DTO;
using NZWalksAPIs.Repositories;

namespace NZWalksAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenrepository _tokenrepository;

        public AuthController(UserManager<IdentityUser> userManager , ITokenrepository tokenrepository)
        {
            _userManager = userManager;
            _tokenrepository = tokenrepository; 
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] Registerrequestdto registerrequestdto)
        {
            var identityuser = new IdentityUser
            {
                UserName = registerrequestdto.Username,
                Email = registerrequestdto.Username
            };

           var identityresult = await _userManager.CreateAsync(identityuser, registerrequestdto.password);
            if (identityresult.Succeeded)
            {
                if(registerrequestdto.Roles != null && registerrequestdto.Roles.Any())
                {
                identityresult = await _userManager.AddToRolesAsync(identityuser,registerrequestdto.Roles);
                 
                    if(identityresult.Succeeded)
                    {
                        return Ok("User Registered successfully.");
                    }
                    else
                    {
                        return BadRequest(identityresult.Errors);
                    }
                }
            }

            return BadRequest("Something went wrong.");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestdto loginRequestdto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestdto.Username);
            if(user != null)
            {
             var chekpassword =   await _userManager.CheckPasswordAsync(user, loginRequestdto.Password);
               if(chekpassword)
                {  
                    var roles  = await _userManager.GetRolesAsync(user);
                    if(roles != null )
                    { 
                      var jwttoken  =   _tokenrepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDto
                        {
                            JwtToken = jwttoken
                        };
                        return Ok(response);
                    }
                   
                }
            }

            return BadRequest("Username or password incorrect");
        }
    }
}
