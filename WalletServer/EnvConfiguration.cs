using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletServer
{
    public class EnvConfiguration
    {
        public string BitcoinUrl { get; set; }
        public string LitecoinUrl { get; set; }
        public string DogecoinUrl { get; set; }
        public string RpcLogin { get; set; }
        public string RpcPassword { get; set; }
    }
}
