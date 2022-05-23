﻿using System;
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
            var wallet = _httpContextAccessor.HttpContext.Request.RouteValues.FirstOrDefault(o => o.Key == "wallet");
            var val = (string)wallet.Value;
            var walletIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(obj => obj.Type == "wallet_id");
            if (walletIdClaim == null)
            {
                return;
            }
            var walletId = walletIdClaim.Value;
            switch (val)
            {
                case "bitcoin":
                    CoreService = new BitcoinService(envConfiguration.BitcoinUrl, envConfiguration.RpcLogin, envConfiguration.RpcPassword, walletId);
                    break;
                case "litecoin":
                    CoreService = new LitecoinService(envConfiguration.LitecoinUrl, envConfiguration.RpcLogin, envConfiguration.RpcPassword, walletId);
                    break;
                case "dogecoin":
                    CoreService = new DogecoinService(envConfiguration.DogecoinUrl, envConfiguration.RpcLogin, envConfiguration.RpcPassword, walletId);
                    break;
                default:
                    CoreService = null;
                    return;
            }
            bool exists = CoreService.ListWallets().Exists(obj => obj == walletId);
            if (exists)
            {
                return;
            }
            try
            {
                CoreService.LoadWallet(walletId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                CoreService.CreateWallet(walletId, false, false);
            }
        }
    }
}