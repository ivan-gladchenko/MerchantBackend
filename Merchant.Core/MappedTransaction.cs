using Merchant.Core.Models;

namespace Merchant.Core
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
