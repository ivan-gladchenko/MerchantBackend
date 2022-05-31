using System;
using System.Threading.Tasks;
using Client.API.Models;
using Client.API.Models.Payment;
using Client.API.Wallet;
using Merchant.Core;
using Merchant.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client.API.Controllers
{
    [Route("api/[controller]/{wallet}")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly MerchantDbContext _context;
        private readonly MerchantContextHandler _contextHandler;

        public PaymentController(MerchantDbContext context, MerchantContextHandler contextHandler)
        {
            _context = context;
            _contextHandler = contextHandler;
        }

        [HttpPost]
        public async Task<MerchantTransaction> Post([FromBody] PaymentRequest payment, string wallet)
        {
            if (_contextHandler.MerchantUser == null)
            {
                Response.StatusCode = 400;
                return null;
            }
            var prices = await WalletManager.GetPrices();
            if (prices.Key <= 0 || prices.Value <= 0)
            {
                Response.StatusCode = 400;
                return null;
            }
            var price = wallet == "bitcoin" ? prices.Key : prices.Value;
            Enum.TryParse<CryptoName>(wallet, out var currency);
            var address = await _contextHandler.WalletManager.GetNewAddress();
            if (string.IsNullOrEmpty(address))
            {
                Response.StatusCode = 400;
                return null;
            }
            var transaction = new MerchantTransaction(_contextHandler.MerchantUser.Id, payment.UahPrice,
                address, price, currency, payment.ProductId);
            transaction = _context.MerchantTransactions.Add(transaction).Entity;
            await _context.SaveChangesAsync();
            return transaction;
        }
    }
}
