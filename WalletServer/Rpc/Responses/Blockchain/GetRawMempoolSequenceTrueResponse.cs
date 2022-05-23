using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.Blockchain
{
    public class GetRawMempoolSequenceTrueResponse
    {
        private List<string> txids { get; set; }
        public double mempool_sequence { get; set; }
    }
}
