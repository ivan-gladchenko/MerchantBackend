using System;
using System.Threading.Tasks;
using IdentityServer.Models;
using Merchant.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task Register(RegisterModel registerModel)
        {
            var user = new AppUser
            {
                UserName = registerModel.username,
                PhoneNumber = registerModel.phone,
                Email = registerModel.email,
                FullName = registerModel.fullname,
                Uuid = Guid.NewGuid().ToString(),
                Role = "user"
            };
            var result = await _userManager.CreateAsync(user, registerModel.password);
            if (!result.Succeeded)
            {
                Response.StatusCode = 400;
            }
        }
        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpPost("register/{role}")]
        public async Task RegisterAdmin(RegisterModel registerModel, string role)
        {
            var user = new AppUser
            {
                UserName = registerModel.username,
                PhoneNumber = registerModel.phone,
                Email = registerModel.email,
                FullName = registerModel.fullname,
                Uuid = Guid.NewGuid().ToString(),
                Role = role
            };
            var result = await _userManager.CreateAsync(user, registerModel.password);
            if (!result.Succeeded)
            {
                Response.StatusCode = 400;
            }
        }
    }
}
