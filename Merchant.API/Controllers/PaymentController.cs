using Merchant.Core;
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
    }
}
