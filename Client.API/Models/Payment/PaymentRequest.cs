using Merchant.Core.Models;

namespace Client.API.Models.Payment
{
    public class PaymentRequest
    {
        public string ProductId { get; set; }
        public double UahPrice { get; set; }
    }
}
