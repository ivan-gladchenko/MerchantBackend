namespace WalletServer.Rpc.Responses.RawTransactions
{
    public class FinalizePsbtResponse
    {
        public string psbt { get; set; }
        public string hex { get; set; }
        public bool complete { get; set; }
    }
}
