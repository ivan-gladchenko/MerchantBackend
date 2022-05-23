using System.Collections.Generic;

namespace WalletServer.Rpc.Entities.Mining
{
    public class GetBlockTemplateRequest
    {
        public string mode { get; set; }
        public List<string> capabilities { get; set; }
        public List<string> rules { get; set; }
    }
}
