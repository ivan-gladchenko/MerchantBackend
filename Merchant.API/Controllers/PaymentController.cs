using System.Security.Claims;
using Merchant.API.Models.Dto;
using Merchant.API.Wallet;
using Merchant.Core;
using Merchant.Core.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Merchant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly MerchantDbContext dbContext;
        private readonly IHubContext<MerchantHub> merchantHub;

        public PaymentController(MerchantDbContext dbContext, IHubContext<MerchantHub> merchantHub)
        {
            this.dbContext = dbContext;
            this.merchantHub = merchantHub;
        }

        [HttpGet]
        public async Task<ActionResult<MerchantTransactionDto>> GetMerchantTransactionDto([FromQuery] string id)
        {
            var merchantTransaction = dbContext.MerchantTransactions.FirstOrDefault(x => x.Id.ToString() == id);
            if (merchantTransaction == null)
            {
                return NotFound();
            }
            var claims = new List<Claim>
            {
                new("id", id),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = true,
                IssuedUtc = DateTime.UtcNow
            };
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            return new MerchantTransactionDto(merchantTransaction);
        }

    }
}
