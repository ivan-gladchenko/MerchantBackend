namespace WalletServer.Rpc.Responses.Wallet
{
    public class AddMultiSigAddressResponse
    {
        public string address { get; set; }
        public string reedemScript { get; set; }
        public string descriptor { get; set; }
    }
}
