namespace WalletServer.Rpc.Responses.Wallet
{
    public class WalletProcessPsbtResponse
    {
        public string psbt { get; set; }
        public bool complete { get; set; }
    }
}
