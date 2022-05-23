using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WalletServer.Rpc.Responses.Wallet
{
    public class GetTransactionResponse
    {
        public double amount { get; set; }
        public double fee { get; set; }
        public long confirmations { get; set; }
        public bool generated { get; set; }
        public bool trusted { get; set; }
        public string blockhash { get; set; }
        public long blockheight { get; set; }
        public long blockindex { get; set; }
        public long blocktime { get; set; }
        public string txid { get; set; }
        public List<string> walletconflicts { get; set; }
        public long time { get; set; }
        public long timereceived { get; set; }
        public string comment { get; set; }
        [JsonPropertyName("bip125-replaceable")]
        public string bip125 { get; set; }
        public Details details { get; set; }
        public string hex { get; set; }
        public dynamic decoded { get; set; }

        public class Details
        {
            public bool involvesWatchonly { get; set; }
            public string address { get; set; }
            public string category { get; set; }
            public double amount { get; set; }
            public string label { get; set; }
            public long vout { get; set; }
            public double fee { get; set; }
            public bool abandoned { get; set; }
        }
    }
}
