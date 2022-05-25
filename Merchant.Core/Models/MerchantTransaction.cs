using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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
        public DateTime CreatedAt { get; set; }
        public DateTime PaidAt { get; set; }
        public DateTime ConfirmedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        [ForeignKey(nameof(MerchantUserId))]
        public MerchantUser MerchantUser { get; set; }
        public long MerchantUserId { get; set; }
        public string ProductId { get; set; }
    }


    public enum CryptoName
    {
        Bitcoin,
        Litecoin,
        Dogecoin
    }
}
