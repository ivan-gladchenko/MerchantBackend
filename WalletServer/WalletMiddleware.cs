using System;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WalletServer.Rpc;

namespace WalletServer
{
    public class WalletMiddleware
    {
        private readonly RequestDelegate _next;
        private EnvConfiguration _envConfiguration;

        public WalletMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context, EnvConfiguration envConfiguration)
        {
            _envConfiguration = envConfiguration;
            ICoreService coreService;
            var wallet = context.Request.RouteValues.FirstOrDefault(o => o.Key == "wallet");
            var val = (string)wallet.Value;
            var walletIdClaim = context.User.Claims.FirstOrDefault(obj => obj.Type == "wallet_id");
            if (walletIdClaim == null)
            {
                return;
            }
            var walletId = walletIdClaim.Value;
            switch (val)
            {
                case "bitcoin":
                    coreService = new BitcoinService(envConfiguration.BitcoinUrl, envConfiguration.RpcLogin, envConfiguration.RpcPassword, walletId);
                    break;
                case "litecoin":
                    coreService = new LitecoinService(envConfiguration.LitecoinUrl, envConfiguration.RpcLogin, envConfiguration.RpcPassword, walletId);
                    break;
                case "dogecoin":
                    coreService = new DogecoinService(envConfiguration.DogecoinUrl, envConfiguration.RpcLogin, envConfiguration.RpcPassword, walletId);
                    break;
                default:
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("No wallet???");
                    return;
            }
            bool exists = coreService.ListWallets().Exists(obj => obj == walletId);
            if (exists)
            {
                await _next.Invoke(context);
                return;
            }
            try
            {
                coreService.LoadWallet(walletId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                coreService.CreateWallet(walletId, false, false);
            }
            await _next.Invoke(context);
        }
    }
}
