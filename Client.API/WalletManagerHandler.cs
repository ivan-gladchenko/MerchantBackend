using System;
using System.Net.Http;
using Client.API.Models;
using Client.API.Wallet;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace Client.API
{
    public class WalletManagerHandler
    {
        public WalletManager WalletManager { get;}

        public WalletManagerHandler(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext == null)
            {
                return;
            }
            var jsonToken = httpContextAccessor.HttpContext.GetTokenAsync("access_token").GetAwaiter().GetResult();
            if (!Enum.TryParse((string)httpContextAccessor.HttpContext.Request.RouteValues["wallet"], out Crypto wallet))
            {
                return;
            }
            var client = new HttpClient();
            client.SetBearerToken(jsonToken);
            WalletManager = new WalletManager(client, wallet);
        }
    }
}
