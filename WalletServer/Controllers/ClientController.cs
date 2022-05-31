using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletServer.Rpc;

namespace WalletServer.Controllers
{
    [Route("api/[controller]/{wallet}")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ICoreService coreService;
        public ClientController(ScopedWallet scopedWallet)
        {
            coreService = scopedWallet.CoreService;
        }

        [HttpGet("address")]
        public string GetAddress()
        {
            return coreService.GetNewAddress();
        }
    }
}
