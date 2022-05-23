using System.Text.Json.Serialization;

namespace WalletServer.Rpc.Responses.RawTransactions
{
    public class TestMempoolAcceptResponse
    {
        public string txid { get; set; }
        public bool allowed { get; set; }

        [JsonPropertyName("reject-reason")]
        public string RejectReason { get; set; }
    }
    
}
