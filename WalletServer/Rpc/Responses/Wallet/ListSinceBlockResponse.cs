using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WalletServer.Rpc.Responses.Wallet
{
    public class ListSinceBlockResponse
    {
        public List<ListSinceBlockTransaction> transactions { get; set; }
        public List<object> removed { get; set; }
        public string lastblock { get; set; }
    }
    public class ListSinceBlockTransaction
    {
        public bool involvesWatchonly { get; set; }
        public string address { get; set; }
        public string category { get; set; }
        public double amount { get; set; }
        public int vout { get; set; }
        public double fee { get; set; }
        public int confirmations { get; set; }
        public bool generated { get; set; }
        public bool trusted { get; set; }
        public string blockhash { get; set; }
        public int blockheight { get; set; }
        public int blockindex { get; set; }
        public int blocktime { get; set; }
        public string txid { get; set; }
        public List<string> walletconflicts { get; set; }
        public int time { get; set; }
        public int timereceived { get; set; }
        public string comment { get; set; }

        [JsonPropertyName("bip125-replaceable")]
        public string Bip125Replaceable { get; set; }
        public bool abandoned { get; set; }
        public string label { get; set; }
        public string to { get; set; }
    }
}
