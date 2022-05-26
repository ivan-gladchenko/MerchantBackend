﻿using Merchant.Core;
using Merchant.Core.Extensions;
using Merchant.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly MerchantDbContext _context;

        public TransactionsController(MerchantDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<MerchantTransaction> GetTransactions([FromQuery] long? userId, [FromQuery] CryptoName? crypto, [FromQuery] string? status)
        {
            return _context.MerchantTransactions.Include(o => o.Id).WhereIf(userId != null,
                    o => o.MerchantUserId == userId)
                .WhereIf(crypto != null,
                    o => o.Crypto == crypto)
                .WhereIf(status != null,
                    o => o.Status == status)
                .ToList();
        }
    }
}
