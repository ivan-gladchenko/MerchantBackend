namespace WalletServer.Rpc.Responses.Wallet
{
    public class ListLockUnspentResponse
    {
        public string txid { get; set; }
        public long vout { get; set; }
    }
}
