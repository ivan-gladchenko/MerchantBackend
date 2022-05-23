using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.Wallet
{
    public class ImportDescriptorsResponse
    {
        public bool success { get; set; }
        public List<string> warnings { get; set; }
        public dynamic error { get; set; }
    }
}
