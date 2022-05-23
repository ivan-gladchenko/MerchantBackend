using System.Collections.Generic;

namespace WalletServer.Rpc.Entities.Wallet
{
    public class ImportMultiObject
    {
        public string desc { get; set; }
        public string scriptPubKey { get; set; }
        public object timestamp { get; set; }
        public string redeemscript { get; set; }
        public string witnessscript { get; set; }
        public List<string> pubkeys { get; set; }
        public List<string> keys { get; set; }
        public object range { get; set; }
        public bool @internal { get; set; }
        public bool watchonly { get; set; }
        public string label { get; set; }
        public bool keypool { get; set; }
    }
}
