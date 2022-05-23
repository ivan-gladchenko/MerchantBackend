namespace WalletServer.Rpc.Responses.Blockchain
{
    public class GetChainTipsResponse
    {
        public int height { get; set; }
        public string hash { get; set; }
        public int branchlen { get; set; }
        public string status { get; set; }
    }
}
