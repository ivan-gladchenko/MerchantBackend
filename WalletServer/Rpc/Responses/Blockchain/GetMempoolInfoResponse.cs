namespace WalletServer.Rpc.Responses.Blockchain
{
    public class GetMempoolInfoResponse
    {
        public bool loaded { get; set; }
        public double size { get; set; }
        public double bytes { get; set; }
        public double usage { get; set; }
        public double maxmempool { get; set; }
        public double mempoolminfee { get; set; }
        public double minrelaytxfee { get; set; }
        public double unbroadcastcount { get; set; }
    }
}
