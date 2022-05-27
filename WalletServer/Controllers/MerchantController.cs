using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WalletServer.Rpc;
using WalletServer.Rpc.Responses.Wallet;

namespace WalletServer.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Merchant")]
    [ApiController]
    public class MerchantController : Controller
    {
        private ICoreService coreService;
        private readonly EnvConfiguration envConfiguration;
        public MerchantController(EnvConfiguration envConfiguration)
        {
            this.envConfiguration = envConfiguration;
        }

        [HttpGet("bitcoin")]
        public List<ListTransactionsResponse> GetBitcoinTransactions([FromQuery] string wallet)
        {
            coreService = new BitcoinService(envConfiguration.BitcoinUrl, envConfiguration.RpcLogin,
                envConfiguration.RpcPassword, wallet);
            return coreService.ListTransactions(count: 100);
        }
        [HttpGet("litecoin")]
        public List<ListTransactionsResponse> GetLitecoinTransactions([FromQuery] string wallet)
        {
            coreService = new LitecoinService(envConfiguration.LitecoinUrl, envConfiguration.RpcLogin,
                envConfiguration.RpcPassword, wallet);
            return coreService.ListTransactions(count: 100);
        }
        [HttpGet("dogecoin")]
        public List<ListTransactionsResponse> GetDogecoinTransactions([FromQuery] string wallet)
        {
            coreService = new BitcoinService(envConfiguration.DogecoinUrl, envConfiguration.RpcLogin,
                envConfiguration.RpcPassword, wallet);
            return coreService.ListTransactions(count: 100);
        }
    }
}
