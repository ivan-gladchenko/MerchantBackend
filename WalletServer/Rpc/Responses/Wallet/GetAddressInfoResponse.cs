using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.Wallet
{
    public class GetAddressInfoResponse
    {
        public string address { get; set; }
        public string scriptPubKey { get; set; }
        public bool ismine { get; set; }
        public bool iswatchonly { get; set; }
        public bool solvable { get; set; }
        public string desc { get; set; }
        public bool isscript { get; set; }
        public bool ischange { get; set; }
        public bool iswitness { get; set; }
        public double witness_version { get; set; }
        public string witness_program { get; set; }
        public string script { get; set; }
        public string hex { get; set; }
        public List<string> pubkeys { get; set; }
        public double signrequired { get; set; }
        public string pubkey { get; set; }
        public dynamic embedded { get; set; }
        public bool iscompressed { get; set; }
        public long timestamp { get; set; }
        public string hdkeypath { get; set; }
        public string hdseedid { get; set; }
        public string hdmasterfingerprint { get; set; }
        public List<string> labels { get; set; }
    }
}
