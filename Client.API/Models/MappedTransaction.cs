using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public Crypto Crypto { get; set; }

    }
    public enum Crypto
    {
        bitcoin = 0,
        litecoin = 1,
        dogecoin = 2,
    }
}
