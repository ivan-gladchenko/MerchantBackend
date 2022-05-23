using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.RawTransactions
{
    public class ScriptSig
    {
        public string asm { get; set; }
        public string hex { get; set; }
    }

    public class Vin
    {
        public string txid { get; set; }
        public int vout { get; set; }
        public ScriptSig scriptSig { get; set; }
        public List<string> txinwitness { get; set; }
        public int sequence { get; set; }
    }

    public class RawTransactionScriptPubKey
    {
        public string asm { get; set; }
        public string hex { get; set; }
        public int reqSigs { get; set; }
        public string type { get; set; }
        public List<string> addresses { get; set; }
    }

    public class Vout
    {
        public double value { get; set; }
        public int n { get; set; }
        public ScriptPubKey scriptPubKey { get; set; }
    }

    public class RawTransactionResponse
    {
        public string txid { get; set; }
        public string hash { get; set; }
        public double size { get; set; }
        public double vsize { get; set; }
        public double weight { get; set; }
        public double version { get; set; }
        public int locktime { get; set; }
        public List<Vin> vin { get; set; }
        public List<Vout> vout { get; set; }
    }
}
