namespace WalletServer.Rpc.Responses.Wallet
{
    public class RescanBlockchainResponse
    {
        public long start_height { get; set; }
        public long stop_height { get; set; }
    }
}
