namespace WalletServer.Rpc.Responses.Mining
{
    public class GetMiningInfoResponse
    {
        public int blocks { get; set; }
        public int currentblockweight { get; set; }
        public int currentblocktx { get; set; }
        public int difficulty { get; set; }
        public int networkhashps { get; set; }
        public int pooledtx { get; set; }
        public string chain { get; set; }
        public string warnings { get; set; }
    }
}
