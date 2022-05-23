using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WalletServer.Rpc.Responses.Blockchain
{
    public class Fees
    {
        public double @base { get; set; }
        public double modified { get; set; }
        public double ancestor { get; set; }
        public double descendant { get; set; }
    }

    public class Transactionid
    {
        public double vsize { get; set; }
        public double weight { get; set; }
        public double fee { get; set; }
        public double modifiedfee { get; set; }
        public int time { get; set; }
        public double height { get; set; }
        public double descendantcount { get; set; }
        public double descendantsize { get; set; }
        public double descendantfees { get; set; }
        public double ancestorcount { get; set; }
        public double ancestorsize { get; set; }
        public double ancestorfees { get; set; }
        public string wtxid { get; set; }
        public Fees fees { get; set; }
        public List<string> depends { get; set; }
        public List<string> spentby { get; set; }

        [JsonPropertyName("bip125-replaceable")]
        public bool Bip125Replaceable { get; set; }
        public bool unbroadcast { get; set; }
    }

    public class GetMempoolResponse
    {
        public Transactionid transactionid { get; set; }
    }
}
