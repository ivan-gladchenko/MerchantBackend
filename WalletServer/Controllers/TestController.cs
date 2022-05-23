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
        private EnvConfiguration _envConfiguration;

        public TestController(EnvConfiguration envConfiguration)
        {
            _envConfiguration = envConfiguration;
            bitcoinService = new BitcoinService(_envConfiguration.BitcoinUrl, _envConfiguration.RpcLogin, _envConfiguration.RpcPassword);
        }

        [HttpGet("getblocks")]
        public long GetBlockCount()
        {
            return bitcoinService.GetBlockCount();
        }

        [HttpPost("create")]
        public string CreateWallet([FromForm] string walletName)
        {
           return bitcoinService.CreateWallet(walletName, false, false).name;
        }

        [HttpPost("unload")]
        public string UnloadWallet([FromForm] string walletName)
        {
            return bitcoinService.UnloadWallet(walletName).warning;
        }
        [HttpPost("load")]
        public string LoadWallet([FromForm] string walletName)
        {
            return bitcoinService.LoadWallet(walletName).warning;
        }

        [HttpGet("wallets")]
        public List<string> ListWallets()
        {
            return bitcoinService.ListWallets();
        }
    }
}
