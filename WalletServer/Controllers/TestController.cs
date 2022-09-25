using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletServer.Rpc;

namespace WalletServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        private ICoreService bitcoinService;
        private ICoreService litecoinService;
        private EnvConfiguration _envConfiguration;

        public TestController(EnvConfiguration envConfiguration)
        {
            _envConfiguration = envConfiguration;
            litecoinService = new LitecoinService(_envConfiguration.LitecoinUrl, _envConfiguration.RpcLogin, _envConfiguration.RpcPassword);
            bitcoinService = new BitcoinService(_envConfiguration.BitcoinUrl, _envConfiguration.RpcLogin, _envConfiguration.RpcPassword);
        }

        [HttpGet("getblocks")]
        public long GetBlockCount()
        {
            return bitcoinService.GetBlockCount();
        }

        [HttpPost("create/btc")]
        public string CreateWalletBtc([FromForm] string walletName)
        {
           return bitcoinService.CreateWallet(walletName, false, false).name;
        }

        [HttpPost("unload/btc")]
        public string UnloadWalletBtc([FromForm] string walletName)
        {
            return bitcoinService.UnloadWallet(walletName).warning;
        }
        [HttpPost("load/btc")]
        public string LoadWalletBtc([FromForm] string walletName)
        {
            return bitcoinService.LoadWallet(walletName).warning;
        }
        [HttpPost("create/ltc")]
        public string CreateWalletLtc([FromForm] string walletName)
        {
            return litecoinService.CreateWallet(walletName, false, false).name;
        }

        [HttpPost("unload/ltc")]
        public string UnloadWalletLtc([FromForm] string walletName)
        {
            return litecoinService.UnloadWallet(walletName).warning;
        }
        [HttpPost("load/ltc")]
        public string LoadWalletLtc([FromForm] string walletName)
        {
            return litecoinService.LoadWallet(walletName).warning;
        }

        [HttpGet("wallets/btc")]
        public List<string> ListWalletsBtc()
        {
            return bitcoinService.ListWallets();
        }
        [HttpGet("wallets/ltc")]
        public List<string> ListWalletsLtc()
        {
            return litecoinService.ListWallets();
        }
    }
}
