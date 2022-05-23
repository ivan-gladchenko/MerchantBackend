using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.Wallet
{
    public class ListReceivedByAddressResponse : ListReceivedByLabelResponse
    {
        public string address { get; set; }
        public List<string> txids { get; set; }
    }
}
