namespace WalletServer.Rpc.Responses.Blockchain
{
    public class Statistics
    {
        public double period { get; set; }
        public double threshold { get; set; }
        public double elapsed { get; set; }
        public double count { get; set; }
        public bool possible { get; set; }
    }

    public class Bip9
    {
        public string status { get; set; }
        public double bit { get; set; }
        public int start_time { get; set; }
        public int timeout { get; set; }
        public double since { get; set; }
        public Statistics statistics { get; set; }
    }

    public class _1x
    {
        public string type { get; set; }
        public Bip9 bip9 { get; set; }
        public double height { get; set; }
        public bool active { get; set; }
    }

    public class Softforks
    {
        public _1x _1x { get; set; }
    }

    public class GetBlockChainInfoResponse
    {
        public string chain { get; set; }
        public double blocks { get; set; }
        public double headers { get; set; }
        public string bestblockhash { get; set; }
        public double difficulty { get; set; }
        public double mediantime { get; set; }
        public double verificationprogress { get; set; }
        public bool initialblockdownload { get; set; }
        public string chainwork { get; set; }
        public double size_on_disk { get; set; }
        public bool pruned { get; set; }
        public double pruneheight { get; set; }
        public bool automatic_pruning { get; set; }
        public double prune_target_size { get; set; }
        public Softforks softforks { get; set; }
        public string warnings { get; set; }
    }
}
