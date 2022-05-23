namespace WalletServer.Rpc.Responses.Util
{
    public class CreateMultiSigResponse
    {
        public string address { get; set; }
        public string reedemScript { get; set; }
        public string descriptor { get; set; }
    }
}
