using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using WalletServer.Rpc;

namespace WalletServer
{
    public class ScopedWallet
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ICoreService CoreService;

        public ScopedWallet(EnvConfiguration envConfiguration, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            if (_httpContextAccessor.HttpContext == null)
            {
                return;
            }
            var val = (string)_httpContextAccessor.HttpContext.Request.RouteValues["wallet"];
            var walletId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(obj => obj.Type == "wallet_id")?.Value ?? _httpContextAccessor.HttpContext.Request.Query["id"].ToString();
            if (walletId == null)
            {
                return;
            }
            switch (val)
            {
                case "bitcoin":
                    CoreService = new BitcoinService(envConfiguration.BitcoinUrl, envConfiguration.RpcLogin, envConfiguration.RpcPassword, walletId);
                    break;
                case "litecoin":
                    CoreService = new LitecoinService(envConfiguration.LitecoinUrl, envConfiguration.RpcLogin, envConfiguration.RpcPassword, walletId);
                    break;
                default:
                    CoreService = null;
                    return;
            }
            bool exists = CoreService.ListWallets()?.Exists(obj => obj == walletId) ?? false;
            if (exists)
            {
                return;
            }
            try
            {
                var resp = CoreService.LoadWallet(walletId);
                if (resp == null)
                {
                    CoreService.CreateWallet(walletId, false, false);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                CoreService.CreateWallet(walletId, false, false);
            }
        }
    }
}
