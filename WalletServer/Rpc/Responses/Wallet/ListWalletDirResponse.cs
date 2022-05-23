using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.Wallet
{
    public class ListWalletDirResponse
    {
        public List<Wallet> wallets { get; set; }
    }
    public class Wallet
    {
        public string name { get; set; }
    }
}
