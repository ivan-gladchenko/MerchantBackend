using Merchant.API.Models.Dto;
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
        public ActionResult<MerchantTransactionDto> GetMerchantTransactionDto([FromQuery] string id)
        {
            var merchantTransaction = dbContext.MerchantTransactions.FirstOrDefault(x => x.Id.ToString() == id);
            if (merchantTransaction == null)
            {
                return NotFound();
            }
            return new MerchantTransactionDto(merchantTransaction);
        }
    }
}
