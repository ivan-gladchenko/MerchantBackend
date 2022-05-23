namespace WalletServer.Rpc.Responses.Blockchain
{
    public class GetChainTxStatsResponse
    {
        public int time { get; set; }
        public int txcount { get; set; }
        public string window_final_block_hash { get; set; }
        public int window_final_block_height { get; set; }
        public int window_block_count { get; set; }
        public int window_tx_count { get; set; }
        public int window_interval { get; set; }
        public int txrate { get; set; }
    }
}
