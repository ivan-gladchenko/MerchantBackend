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
        public async Task<ActionResult<MerchantTransaction>> Post([FromBody] PaymentRequest payment, string wallet)
        {
            if (_contextHandler.MerchantUser == null)
            {
                return Unauthorized("Wrong or no ApiKey");
            }

            if (!Uri.TryCreate(_contextHandler.MerchantUser.WebhookAddress, UriKind.Absolute, out var url))
            {
                return BadRequest("Set webhook address");
            }
            var prices = await WalletManager.GetPrices();
            if (prices.Key <= 0 || prices.Value <= 0)
            {
                return BadRequest("Cant get prices");
            }
            var price = wallet == "bitcoin" ? prices.Key : prices.Value;
            Enum.TryParse<CryptoName>(wallet, out var currency);
            var address = await _contextHandler.WalletManager.GetNewAddress();
            if (string.IsNullOrEmpty(address))
            {
                return BadRequest("Cant create address");
            }
            var transaction = new MerchantTransaction(_contextHandler.MerchantUser.Id, payment.UahPrice,
                address, price, currency, payment.ProductId);
            transaction = _context.MerchantTransactions.Add(transaction).Entity;
            await _context.SaveChangesAsync();
            return transaction;
        }
    }
}
