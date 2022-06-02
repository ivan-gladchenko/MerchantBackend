using System.Text.Json.Serialization;
using Merchant.Core.Models;

namespace Merchant.API.Models.Dto
{
    public class MerchantTransactionDto
    {
        public string Id { get; set; }
        public CryptoName Crypto { get; set; }
        public double Value { get; set; }
        public string Address { get; set; }
        public double Uah { get; set; }
        public string Txid { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TransactionStatus Status { get; set; }
        public DateTime ExpiresAt { get; set; }

        public MerchantTransactionDto(MerchantTransaction merchantTransaction)
        {
            Id = merchantTransaction.Id.ToString("D");
            Crypto = merchantTransaction.Crypto;
            Value = merchantTransaction.Value;
            Address = merchantTransaction.Address;
            Uah = merchantTransaction.Uah;
            Txid = merchantTransaction.Txid;
            ExpiresAt = merchantTransaction.ExpiresAt;
            Status = merchantTransaction.Status;
        }
    }
}
