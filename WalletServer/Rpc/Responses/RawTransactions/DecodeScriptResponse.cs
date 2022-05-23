using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WalletServer.Rpc.Responses.RawTransactions
{
    public class Segwit
    {
        public string asm { get; set; }
        public string hex { get; set; }
        public string type { get; set; }
        public int reqSigs { get; set; }
        public List<string> addresses { get; set; }

        [JsonPropertyName("p2sh-segwit")]
        public string P2shSegwit { get; set; }
    }

    public class DecodeScriptResponse
    {
        public string asm { get; set; }
        public string type { get; set; }
        public int reqSigs { get; set; }
        public List<string> addresses { get; set; }
        public string p2sh { get; set; }
        public Segwit segwit { get; set; }
    }


}
