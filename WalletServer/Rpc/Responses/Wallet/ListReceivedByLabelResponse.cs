namespace WalletServer.Rpc.Responses.Wallet
{
    public class ListReceivedByLabelResponse
    {
        public bool involvesWatchonly { get; set; }
        public double amount { get; set; }
        public double confirmations { get; set; }
        public string label { get; set; }
    }
}
