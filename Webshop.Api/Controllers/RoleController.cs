using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Api.Data;
using Webshop.Api.Models;

namespace Webshop.Api.Controllers
{
    [Route("/role/")]
    [ApiController]
    public class RoleController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(
            ApplicationDbContext applicationDbContext, 
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = applicationDbContext;
            _roleManager = roleManager;
        }
        
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoleToUser(String userName, String roleName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if(user == null)
            {
                return BadRequest($"The user with {userName} does not exists");
            }

            var roleExists = await _roleManager.RoleExistsAsync(roleName);

            if(!roleExists)
            {
                if (user == null)
                {
                    return BadRequest($"The user with {roleName} does not exists");
                }
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);
            if(result.Succeeded)
            {
                return Ok($"{roleName} has been assigned {roleName}");
            }
            else
            {
                return BadRequest($"Can't add role: {roleName} to user");
            }
        }

        [HttpGet]
        [Route("getUserRoles")]
        public async Task<IActionResult> getUserRoles(String userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return BadRequest($"The user with {userName} does not exists");
            }

            var roles = await _userManager.GetRolesAsync(user);

            return Ok(roles);
        }
    }
}
