namespace WalletServer.Rpc.Responses.Blockchain
{
    public class GetTxOutSetInfoResponse
    {
        public int height { get; set; }
        public string bestblock { get; set; }
        public int transactions { get; set; }
        public int txouts { get; set; }
        public int bogosize { get; set; }
        public string hash_serialized_2 { get; set; }
        public int disk_size { get; set; }
        public double total_amount { get; set; }
    }
}
