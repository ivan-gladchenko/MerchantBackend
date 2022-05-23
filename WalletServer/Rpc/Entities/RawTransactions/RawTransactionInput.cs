namespace WalletServer.Rpc.Entities.RawTransactions
{
    public class RawTransactionInput
    {
        public string txid { get; set; }
        public long vout { get; set; }
        public long sequence { get; set; }
    }
}
