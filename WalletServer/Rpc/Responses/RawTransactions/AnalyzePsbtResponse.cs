using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.RawTransactions
{
    public class Missing
    {
        public List<string> pubkeys { get; set; }
        public List<string> signatures { get; set; }
        public string redeemscript { get; set; }
        public string witnessscript { get; set; }
    }

    public class Input
    {
        public bool has_utxo { get; set; }
        public bool is_final { get; set; }
        public Missing missing { get; set; }
        public string next { get; set; }
    }

    public class AnalyzePsbtResponse
    {
        public List<Input> inputs { get; set; }
        public double estimated_vsize { get; set; }
        public double estimated_feerate { get; set; }
        public double fee { get; set; }
        public string next { get; set; }
        public string error { get; set; }
    }
}
