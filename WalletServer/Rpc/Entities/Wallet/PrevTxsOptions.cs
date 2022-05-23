namespace WalletServer.Rpc.Entities.Wallet
{
    public class PrevTxsOptions
    {
        public string txid { get; set; }
        public int vout { get; set; }
        public string scriptPubKey { get; set; }
        public string redeemScript { get; set; }
        public string witnessScript { get; set; }
        public double amount { get; set; }
    }
}
