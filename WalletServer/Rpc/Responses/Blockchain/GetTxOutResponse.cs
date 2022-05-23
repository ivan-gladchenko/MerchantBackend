using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.Blockchain
{ 
    public class ScriptPubKey
    {
        public string asm { get; set; }
        public string hex { get; set; }
        public double reqSigs { get; set; }
        public string type { get; set; }
        public List<string> addresses { get; set; }
    }

    public class GetTxOutResponse
    {
        public string bestblock { get; set; }
        public int confirmations { get; set; }
        public double value { get; set; }
        public ScriptPubKey scriptPubKey { get; set; }
        public bool coinbase { get; set; }
    }
}
