namespace WalletServer.Rpc.Responses.Wallet
{
    public class ListUnspentResponse
    {
        public string txid { get; set; }
        public int vout { get; set; }
        public string address { get; set; }
        public string label { get; set; }
        public string scriptPubKey { get; set; }
        public double amount { get; set; }
        public int confirmations { get; set; }
        public string redeemScript { get; set; }
        public string witnessScript { get; set; }
        public bool spendable { get; set; }
        public bool solvable { get; set; }
        public bool reused { get; set; }
        public string desc { get; set; }
        public bool safe { get; set; }
    }
}
