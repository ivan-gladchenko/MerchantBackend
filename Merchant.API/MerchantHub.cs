using Microsoft.AspNetCore.SignalR;

namespace Merchant.API
{
    public class MerchantHub : Hub
    {
        public MerchantHub()
        {
            
        }

        public override Task OnConnectedAsync()
        {
            var transactionId = Context.GetHttpContext()?.Request.Headers["transaction"].ToString();
            if (transactionId != null)
                Groups.AddToGroupAsync(Context.ConnectionId, transactionId);
            return base.OnConnectedAsync();
        }
    }
}
