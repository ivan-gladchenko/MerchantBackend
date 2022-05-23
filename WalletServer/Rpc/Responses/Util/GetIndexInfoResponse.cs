namespace WalletServer.Rpc.Responses.Util
{
    public class GetIndexInfoResponse
    {
        public Index name { get; set; }

        public class Index
        {
            public bool synced { get; set; }
            public long best_block_height { get; set; }
        }
    }
}
