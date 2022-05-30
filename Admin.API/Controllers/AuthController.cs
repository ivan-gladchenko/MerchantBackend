using Admin.API.Models;
using IdentityModel.Client;
using Merchant.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MerchantDbContext _context;
        private readonly HttpClient _httpClient;
        public AuthController(MerchantDbContext context)
        {
            _context = context;
            _httpClient = new HttpClient();
        }

        [HttpPost("login")]
        public async Task<LoginResponse> Login(LoginModel model)
        {
            var user = _context.Users.FirstOrDefault(o => o.UserName == model.login && o.Role == "admin");
            if (user == null)
            {
                Response.StatusCode = 401;
                return new LoginResponse
                {
                    error = "No user found"
                };
            }

            var resp = await _httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                UserName = model.login,
                Password = model.password,
                Address = "http://127.0.0.1:2000/connect/token",
                ClientId = "web_admin",
                ClientSecret = "admin_secret_key",
                Scope = "AdminPanel"
            });
            if (resp.IsError)
            {
                Response.StatusCode = 401;
            }
            return new LoginResponse
            {
                accessToken = resp.AccessToken,
                error = resp.Error,
                expireTime = resp.ExpiresIn
            };
        }
    }
}
