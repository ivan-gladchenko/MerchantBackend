using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletServer.Models
{
    public class SendCryptoModel
    {
        public string address { get; set; }
        public double value { get; set; }
    }
}
