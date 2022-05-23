namespace WalletServer.Rpc.Responses.Network
{
    public class GetNodeAddressesResponse
    {
        public int time { get; set; }
        public int services { get; set; }
        public string address { get; set; }
        public int port { get; set; }
    }
}
