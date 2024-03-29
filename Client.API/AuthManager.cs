﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Client.API.Models;
using IdentityModel.Client;
using Merchant.Core;
using Merchant.Core.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;

namespace Client.API
{
    public class AuthManager
    {
        private readonly MerchantDbContext _dbContext;
        private readonly HttpClient httpClient;

        public AuthManager(MerchantDbContext dbContext)
        {
            _dbContext = dbContext;
            httpClient = new HttpClient();
        }

        public async Task<LoginResponse> Login(LoginModel loginModel)
        {
            var token = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                UserName = loginModel.login,
                Password = loginModel.password,
                Address = "http://127.0.0.1:2000/connect/token",
                ClientId = "web_client",
                ClientSecret = "client_secret_key",
                Scope = "WalletServer",

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
                var user = _dbContext.Users.FirstOrDefault(o => o.UserName == registerModel.username);
                if (user != null)
                {
                    return new LoginResponse
                    {
                        error = "User exists"
                    };
                }
                var result = await httpClient.PostAsync(new Uri("http://127.0.0.1:2000/api/auth/register"),
                    new StringContent(JsonConvert.SerializeObject(registerModel), Encoding.UTF8,
                        MediaTypeNames.Application.Json));
                if (!result.IsSuccessStatusCode)
                {
                    return new LoginResponse
                    {
                        error = "Can't register user"
                    };
                }
                var merchantUser = new MerchantUser
                {
                    ApiKey = Guid.NewGuid().ToString("N"),
                    AppUserName = registerModel.username,
                    WebhookAddress = string.Empty
                };
                await _dbContext.MerchantUsers.AddAsync(merchantUser);
                await _dbContext.SaveChangesAsync();
                return await Login(new LoginModel
                {
                    login = registerModel.username,
                    password = registerModel.password
                });
            }
            catch (HttpRequestException e)
            {
                return new LoginResponse
                {
                    error = e.Message
                };
            }
        }
    }
}
