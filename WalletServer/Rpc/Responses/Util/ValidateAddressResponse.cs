namespace WalletServer.Rpc.Responses.Util
{
    public class ValidateAddressResponse
    {
        public bool isvalid { get; set; }
        public string address { get; set; }
        public string scriptPubKey { get; set; }
        public bool isscript { get; set; }
        public bool iswitness { get; set; }
        public double witness_version { get; set; }
        public string witness_program { get; set; }
    }
}
