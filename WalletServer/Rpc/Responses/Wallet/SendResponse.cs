namespace WalletServer.Rpc.Responses.Wallet
{
    public class SendResponse
    {
        public bool complete { get; set; }
        public string txid { get; set; }
        public string hex { get; set; }
        public string psbt { get; set; }
    }
}
