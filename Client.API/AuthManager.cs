using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Client.API.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;

namespace Client.API
{
    public class AuthManager
    {
        private readonly HttpClient httpClient;

        public AuthManager()
        {
            httpClient = new HttpClient();
        }

        public async Task<LoginResponse> Login(LoginModel loginModel)
        {
            var token = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                UserName = loginModel.login,
                Password = loginModel.password,
                Address = "http://127.0.0.1:2000/connect/token",
                ClientId = "wallet_server_client",
                ClientSecret = "secret_key",
                Scope = "WalletServer"
            });
            return new LoginResponse
            {
                accessToken = token.AccessToken,
                expireTime = token.ExpiresIn,
                error = token.ErrorDescription
            };
        }

        public async Task<LoginResponse> Register(RegisterModel registerModel)
        {
            try
            {
                await httpClient.PostAsync(new Uri("http://127.0.0.1:2000/api/auth/register"),
                    new StringContent(JsonConvert.SerializeObject(registerModel), Encoding.UTF8,
                        MediaTypeNames.Application.Json));
                return await Login(new LoginModel
                {
                    login = registerModel.username,
                    password = registerModel.password
                });
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.BadRequest)
                {
                    return null;
                }
                throw new Exception("Identity Server error.");
            }
        }
    }
}
