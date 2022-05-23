using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using WalletServer.Models;
using WalletServer.Rpc;
using WalletServer.Rpc.Responses.Wallet;

namespace WalletServer.Controllers
{
    [Route("api/[controller]/{wallet}")]
    [Authorize]
    [ApiController]
    public class WalletController : Controller
    {
        private readonly ICoreService coreService;

        public WalletController(ScopedWallet scopedWallet)
        {
            coreService = scopedWallet.CoreService;
        }
        [HttpGet("balance")]
        public double GetBalance()
        {
            return coreService.GetBalance();
        }

        [HttpGet("create/address")]
        public string GenerateAddress()
        {
            return coreService.GetNewAddress();
        }

        [HttpGet("transactions")]
        public List<ListTransactionsResponse> GetTransactions()
        {
            return coreService.ListTransactions(count: 100);
        }

        [HttpPost("send")]
        public string Send(SendCryptoModel model)
        {
            try
            {
                return coreService.SendToAddress(model.address, model.value);
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return e.Message;
            }
        }
    }
}
