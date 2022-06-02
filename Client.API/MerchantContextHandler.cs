using System;
using System.Linq;
using System.Net.Http;
using Client.API.Models;
using Client.API.Wallet;
using IdentityModel.Client;
using Merchant.Core;
using Merchant.Core.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace Client.API
{
    public class MerchantContextHandler
    {
        public WalletManager WalletManager { get;}
        public MerchantUser MerchantUser { get; }

        public MerchantContextHandler(MerchantDbContext context ,IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext == null)
            {
                return;
            }
            if (!Enum.TryParse((string)httpContextAccessor.HttpContext.Request.RouteValues["wallet"], out CryptoName wallet))
            {
                return;
            }
            var apiKey = httpContextAccessor.HttpContext.Request.Headers["ApiKey"].ToString();
            if (!string.IsNullOrEmpty(apiKey))
            {
                MerchantUser = context.MerchantUsers.FirstOrDefault(o => o.ApiKey == apiKey);
                if (MerchantUser == null)
                {
                    return;
                }
                var id = context.Users.FirstOrDefault(o => o.UserName == MerchantUser.AppUserName)?.Uuid;
                WalletManager = new WalletManager(wallet, id);
                return;
            }
            var jsonToken = httpContextAccessor.HttpContext.GetTokenAsync("access_token").GetAwaiter().GetResult();
            var client = new HttpClient();
            client.SetBearerToken(jsonToken);
            WalletManager = new WalletManager(client, wallet);
        }
    }
}
