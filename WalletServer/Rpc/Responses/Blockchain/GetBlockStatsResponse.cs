using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.Blockchain
{
    public class GetBlockStatsResponse
    {
        public double avgfee { get; set; }
        public double avgfeerate { get; set; }
        public double avgtxsize { get; set; }
        public string blockhash { get; set; }
        public List<double> feerate_percentiles { get; set; }
        public double height { get; set; }
        public double ins { get; set; }
        public double maxfee { get; set; }
        public double maxfeerate { get; set; }
        public double maxtxsize { get; set; }
        public double medianfee { get; set; }
        public double mediantime { get; set; }
        public double mediantxsize { get; set; }
        public double minfee { get; set; }
        public double minfeerate { get; set; }
        public double mintxsize { get; set; }
        public double outs { get; set; }
        public double subsidy { get; set; }
        public double swtotal_size { get; set; }
        public double swtotal_weight { get; set; }
        public double swtxs { get; set; }
        public double time { get; set; }
        public double total_out { get; set; }
        public double total_size { get; set; }
        public double total_weight { get; set; }
        public double totalfee { get; set; }
        public double txs { get; set; }
        public double utxo_increase { get; set; }
        public double utxo_size_inc { get; set; }
    }
}
