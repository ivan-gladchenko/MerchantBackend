namespace WalletServer.Rpc.Responses.Wallet
{
    public class SendManyResponse
    {
        public string txid { get; set; }
        public string fee_reason { get; set; }
    }
}
