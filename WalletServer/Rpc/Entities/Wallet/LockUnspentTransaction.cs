namespace WalletServer.Rpc.Entities.Wallet
{
    public class LockUnspentTransaction
    {
        public string txid { get; set; }
        public long vout { get; set; }
    }
}
