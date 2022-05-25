using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Core.Models
{
    [Table("MerchantUsers")]
    public class MerchantUser
    {
        [Key]
        public long Id { get; set; }
        public string AppUserName { get; set; }
        public string ApiKey { get; set; }
        public string WebhookAddress { get; set; }
        public List<MerchantTransaction> MerchantTransactions { get; set; }
    }
}
