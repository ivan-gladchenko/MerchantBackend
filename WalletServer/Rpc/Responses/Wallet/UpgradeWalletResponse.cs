namespace WalletServer.Rpc.Responses.Wallet
{
    public class UpgradeWalletResponse
    {
        public string wallet_name { get; set; }
        public long previous_version { get; set; }
        public long current_version { get; set; }
        public string result { get; set; }
        public string error { get; set; }
    }
}
