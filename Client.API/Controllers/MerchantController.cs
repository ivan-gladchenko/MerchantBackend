using System.Collections.Generic;
using System.Linq;
using Client.API.Wallet;
using Merchant.Core;
using Merchant.Core.Extensions;
using Merchant.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly MerchantDbContext _context;
        public MerchantController(MerchantDbContext context)
        {
            _context = context;
        }

        [HttpGet("transactions")]
        public List<MerchantTransaction> GetMerchantTransactions([FromQuery] TransactionStatus? status, [FromQuery] CryptoName? crypto, [FromQuery] string productId)
        {
            var merchantUser = _context.MerchantUsers.FirstOrDefault(o => o.AppUserName == User.Identity.Name);
            return _context.MerchantTransactions.Where(o => o.MerchantUserId == merchantUser.Id)
                .AsEnumerable()
                .WhereIf(status != null,
                    o => o.Status == status)
                .WhereIf(crypto != null,
                    o => o.Crypto == crypto)
                .WhereIf(productId != null,
                    o => o.ProductId == productId)
                .OrderByDescending(o => o.CreatedAt)
                .ToList();
        }
    }
}
