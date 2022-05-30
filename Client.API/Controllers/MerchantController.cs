using System.Collections.Generic;
using Client.API.Wallet;
using Merchant.Core;
using Merchant.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly MerchantDbContext _context;
        private readonly WalletManager _walletManager;
        public MerchantController(MerchantDbContext context, WalletManagerHandler walletManagerHandler)
        {
            _walletManager = walletManagerHandler.WalletManager;
            _context = context;
        }

        [HttpGet]
        public List<MerchantTransaction> GetMerchantTransactions()
        {
            return new List<MerchantTransaction>();
        }
    }
}
