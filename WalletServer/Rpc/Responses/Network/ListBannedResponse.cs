namespace WalletServer.Rpc.Responses.Network
{
    public class ListBannedResponse
    {
        public string address { get; set; }
        public int banned_until { get; set; }
        public int ban_created { get; set; }
    }
}
