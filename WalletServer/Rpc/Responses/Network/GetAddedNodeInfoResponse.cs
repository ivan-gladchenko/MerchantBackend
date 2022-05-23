using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.Network
{
    public class Address
    {
        public string address { get; set; }
        public string connected { get; set; }
    }

    public class GetAddedNodeInfoResponse
    {
        public string addednode { get; set; }
        public bool connected { get; set; }
        public List<Address> addresses { get; set; }
    }
}
