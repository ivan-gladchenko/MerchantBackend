using System.Text.Json.Serialization;

namespace Merchant.API.Wallet
{
    public class CoreTransaction
    {
        public string address { get; set; }
        public double amount { get; set; }
        [JsonPropertyName("bip125-replaceable")]
        public string bip125 { get; set; }
        public string blockhash { get; set; }
        public int blockheight { get; set; }
        public int blockindex { get; set; }
        public int blocktime { get; set; }
        public string category { get; set; }
        public double fee { get; set; }
        public int confirmations { get; set; }
        public string label { get; set; }
        public int time { get; set; }
        public int timereceived { get; set; }
        public string txid { get; set; }
        public int vout { get; set; }
        public List<object> walletconflicts { get; set; }
    }
}
