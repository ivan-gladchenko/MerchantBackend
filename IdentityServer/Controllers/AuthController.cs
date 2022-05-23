using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.Db;
using IdentityServer.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

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
        public async void Register(RegisterModel registerModel)
        {
            var user = new AppUser
            {
                UserName = registerModel.username,
                PhoneNumber = registerModel.phone,
                Email = registerModel.email,
                FullName = registerModel.fullname,
                Uuid = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, registerModel.password);
            if (!result.Succeeded)
            {
                Response.StatusCode = 400;
            }
        }
    }
}
