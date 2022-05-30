using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Merchant.Core;
using Microsoft.AspNetCore.Http;

namespace Client.API.Wallet
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly MerchantDbContext _context;
        public ApiKeyMiddleware(RequestDelegate next, MerchantDbContext context)
        {
            _next = next;
            _context = context;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Path.StartsWithSegments(new PathString("api/payment")))
            {
                await _next(context);
                return;
            }
            var apiKey = context.Request.Headers["ApiKey"].ToString();
            if (_context.MerchantUsers.FirstOrDefault(o => o.ApiKey == apiKey) != null)
            {
                context.Response.StatusCode = 401;
                return;
            }

            context.User = new GenericPrincipal(new GenericIdentity("name"), new[] { "admin" });
            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }
    }
}
