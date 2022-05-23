using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.Control
{
    public class ActiveCommand
    {
        public string method { get; set; }
        public double duration { get; set; }
    }

    public class GetRpcInfoResponse
    {
        public List<ActiveCommand> active_commands { get; set; }
        public string logpath { get; set; }
    }
}
