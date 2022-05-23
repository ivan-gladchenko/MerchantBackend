namespace WalletServer.Rpc.Responses.Wallet
{
    public class WalletCreateFundedPsbtResponse
    {
        public string psbt { get; set; }
        public double fee { get; set; }
        public long changepos { get; set; }
    }
}
