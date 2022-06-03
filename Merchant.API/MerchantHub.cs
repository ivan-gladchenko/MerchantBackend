using Merchant.Core.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Merchant.API
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class MerchantHub : Hub
    {
        public MerchantHub()
        {
            
        }

        public override Task OnConnectedAsync()
        {
            var transactionId = Context.GetHttpContext()?.User.Claims.FirstOrDefault(o => o.Type == "id")?.Value;
            Console.WriteLine($"Transid: {transactionId}");
            if (transactionId != null)
                 Groups.AddToGroupAsync(Context.ConnectionId, transactionId).GetAwaiter().GetResult();
            return base.OnConnectedAsync();
        }

    }
}
