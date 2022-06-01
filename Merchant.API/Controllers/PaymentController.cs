using Merchant.API.Wallet;
using Merchant.Core;
using Merchant.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Merchant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly MerchantDbContext dbContext;

        public PaymentController(MerchantDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<List<CoreTransaction>?> GetTransactions([FromQuery] CryptoName cryptoName, [FromQuery] string walletId)
        {
            TransactionsHandler handler = new TransactionsHandler(dbContext);
            return await handler.GetTransactions(cryptoName, walletId);
        }
    }
}
