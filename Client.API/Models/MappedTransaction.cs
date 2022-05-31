using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merchant.Core.Models;

namespace Client.API.Models
{
    public class MappedTransaction
    {
        public string Address { get; set; }
        public double Value { get; set; }
        public string Txid { get; set; }
        public bool @in { get; set; }
        public int Confirmations { get; set; }
        public DateTime Date { get; set; }
        public CryptoName Crypto { get; set; }

    }
}
