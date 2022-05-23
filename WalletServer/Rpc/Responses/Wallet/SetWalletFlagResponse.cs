namespace WalletServer.Rpc.Responses.Wallet
{
    public class SetWalletFlagResponse
    {
        public string flag_name { get; set; }
        public bool flag_state { get; set; }
        public string warnings { get; set; }
    }
}
