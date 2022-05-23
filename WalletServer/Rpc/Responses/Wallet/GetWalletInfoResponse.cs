namespace WalletServer.Rpc.Responses.Wallet
{
    public class Scanning
    {
        public int duration { get; set; }
        public double progress { get; set; }
    }

    public class GetWalletInfoResponse
    {
        public string walletname { get; set; }
        public double walletversion { get; set; }
        public string format { get; set; }
        public double balance { get; set; }
        public double unconfirmed_balance { get; set; }
        public double immature_balance { get; set; }
        public int txcount { get; set; }
        public int keypoololdest { get; set; }
        public int keypoolsize { get; set; }
        public int keypoolsize_hd_internal { get; set; }
        public int unlocked_until { get; set; }
        public int paytxfee { get; set; }
        public string hdseedid { get; set; }
        public bool private_keys_enabled { get; set; }
        public bool avoid_reuse { get; set; }
        public Scanning scanning { get; set; }
        public bool descriptors { get; set; }
    }
}
