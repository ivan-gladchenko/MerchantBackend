namespace WalletServer.Rpc.Responses.Util
{
    public class GetDescriptorInfoResponse
    {
        public string descriptor { get; set; }
        public string checksum { get; set; }
        public bool isrange { get; set; }
        public bool issolvable { get; set; }
        public bool hasprivatekeys { get; set; }
    }
}
