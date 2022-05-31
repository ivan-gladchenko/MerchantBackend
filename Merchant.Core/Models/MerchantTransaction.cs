using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Merchant.Core.Models
{
    [Table("MerchantTransactions")]
    public class MerchantTransaction
    {
        [Key]
        public Guid Id { get; set; }
        public CryptoName Crypto { get; set; }
        public double Value { get; set; }
        public string Address { get; set; }
        public double CryptoPrice { get; set; }
        public double Uah { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PaidAt { get; set; }
        public DateTime ConfirmedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        [ForeignKey(nameof(MerchantUserId))]
        [JsonIgnore]
        public MerchantUser MerchantUser { get; set; }
        public long MerchantUserId { get; set; }
        public string ProductId { get; set; }

        public MerchantTransaction()
        {
            
        }

        public MerchantTransaction(long merchantUserId, double uah, string address, double cryptoPrice, CryptoName crypto, string productId)
        {
            Crypto = crypto;
            Value = Math.Round(uah / cryptoPrice, 6);
            Uah = uah;
            Address = address;
            CryptoPrice = cryptoPrice;
            MerchantUserId = merchantUserId;
            CreatedAt = DateTime.UtcNow;
            ExpiresAt = CreatedAt.AddHours(2);
            ProductId = productId;
            Status = "Created";

        }
    }


    public enum CryptoName
    {
        bitcoin,
        litecoin
    }
}
