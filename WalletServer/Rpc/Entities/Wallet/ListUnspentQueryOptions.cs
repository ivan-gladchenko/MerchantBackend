namespace WalletServer.Rpc.Entities.Wallet
{
    public class ListUnspentQueryOptions
    {
        public double minimumAmount { get; set; }
        public double maximumAmount { get; set; }
        public long maximumCount { get; set; }
        public double minimumSumAmount { get; set; }
    }
}
