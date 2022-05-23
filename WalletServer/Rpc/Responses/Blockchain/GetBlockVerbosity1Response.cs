using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.Blockchain
{
    public class GetBlockVerbosity1Response
    {
        public string hash { get; set; }
        public double confirmations { get; set; }
        public double size { get; set; }
        public double strippedsize { get; set; }
        public double weight { get; set; }
        public double height { get; set; }
        public double version { get; set; }
        public string versionHex { get; set; }
        public string merkleroot { get; set; }
        public List<string> tx { get; set; }
        public int time { get; set; }
        public int mediantime { get; set; }
        public double nonce { get; set; }
        public string bits { get; set; }
        public double difficulty { get; set; }
        public string chainwork { get; set; }
        public double nTx { get; set; }
        public string previousblockhash { get; set; }
        public string nextblockhash { get; set; }
    }
}
