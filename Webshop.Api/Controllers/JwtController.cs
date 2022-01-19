using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebShopApp.Configurations;
using WebShopApp.Models;
using WebShopApp.Models.JwtModels;

namespace WebShopApp.Controllers
{
    [Route("/auth/")]
    [ApiController]
    public class JwtController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly RoleManager<IdentityRole> _roleManager;

        public JwtController(
            UserManager<ApplicationUser> userManager,
            IOptionsMonitor<JwtConfig> optionsMonitor,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDTO userRegistrationDTO)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByNameAsync(userRegistrationDTO.Username);

                if (existingUser != null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<String>()
                        {
                            "Username already in use"
                        },
                        Success = false
                    });
                }

                var newUser = new ApplicationUser()
                {
                    UserName = userRegistrationDTO.Username,
                };

                var isCreated = await _userManager.CreateAsync(newUser, userRegistrationDTO.Password);

                if (isCreated.Succeeded)
                {
                    var addRole = await _userManager.AddToRoleAsync(newUser, "USER");

                    var jwtToken = await GenerateJwtTokenAsync(newUser);
                    return Ok(new RegistrationResponse()
                    {
                        Success = true,
                        Token = jwtToken
                    }); ;

                }
                else
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = isCreated.Errors.Select(error => error.Description).ToList(),
                        Success = false
                    });
                }
            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<String>()
                {
                    "Errors"
                },
                Success = false
            });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(userLoginRequest.Email);

                if (existingUser == null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<String>()
                        {
                            "Invalid login request"
                        },
                        Success = false
                    });
                }

                var isPasswordCorrect = await _userManager.CheckPasswordAsync(existingUser, userLoginRequest.Password);

                if (!isPasswordCorrect)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<String>()
                        {
                            "Username or password is wrong"
                        },
                        Success = false
                    });
                }

                var jwtToken = await GenerateJwtTokenAsync(existingUser);

                return Ok(new RegistrationResponse()
                {
                    Success = true,
                    Token = jwtToken
                });
            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<String>()
                        {
                            "Invalid payload"
                        },
                Success = false
            });
        }

        private async Task<String> GenerateJwtTokenAsync(ApplicationUser user)
        {
            var JwtTokenHandler = new JwtSecurityTokenHandler();

            var secret = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var claims = await GetValidClaims(user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256)
            };

            var jwtToken = JwtTokenHandler.WriteToken(JwtTokenHandler.CreateToken(tokenDescriptor));

            return jwtToken;
        }

        private async Task<List<Claim>> GetValidClaims(ApplicationUser user)
        {
            var options = new IdentityOptions();

            var claims = new List<Claim>
            {
                new Claim("id", user.Id),
                new Claim(JwtRegisteredClaimNames.UniqueName ,user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                // Future refresh token
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userClaims = await _userManager.GetClaimsAsync(user);
            if(userClaims == null)
            {

            }
            claims.AddRange(userClaims);

            var userRoles = await _userManager.GetRolesAsync(user);
            
            foreach(var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));

                var role = await _roleManager.FindByNameAsync(userRole);

                if(role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach(var roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }
            return claims;
        }
    }
}
