using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Client.API.Models;
using IdentityModel.Client;
using Merchant.Core;

namespace Client.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthManager authManager;
        public AuthController(MerchantDbContext dbContext)
        {
            authManager = new AuthManager(dbContext);
        }


        [HttpPost("login")]
        public async Task<LoginResponse> Login(LoginModel loginModel)
        {
            var resp = await authManager.Login(loginModel);
            if (resp.error != null)
            {
                Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            return resp;
        }

        [HttpPost("register")]
        public async Task<LoginResponse> Register(RegisterModel registerModel)
        {
            var resp = await authManager.Register(registerModel);
            if (resp.error != null)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            return resp;
        }
    }
}
