using Admin.API.Models;
using IdentityModel;
using IdentityModel.Client;
using IdentityServer.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthModel model)
        {
            var code = _httpClient.RequestTokenAsync(new AuthorizationCodeTokenRequest
            {
                Address = "http://127.0.0.1:2000/connect/authorize",
                ClientId = "web_admin",
                ClientSecret = "admin_secret_key",
                GrantType = OidcConstants.GrantTypes.AuthorizationCode
            });
            await _httpClient.RequestAuthorizationCodeTokenAsync(new AuthorizationCodeTokenRequest
            {
                Address = "http://127.0.0.1:2000/connect/token",
                ClientId = "web_admin",
                ClientSecret = "admin_secret_key",
                Code = "code",

            });
        }
    }
}
