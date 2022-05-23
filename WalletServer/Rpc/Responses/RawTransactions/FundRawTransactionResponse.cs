namespace WalletServer.Rpc.Responses.RawTransactions
{
    public class FundRawTransactionResponse
    {
        public string hex { get; set; }
        public double fee { get; set; }
        public long changepos { get; set; }
    }
}
