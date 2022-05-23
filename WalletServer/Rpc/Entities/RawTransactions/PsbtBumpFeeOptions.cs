namespace WalletServer.Rpc.Entities.RawTransactions
{
    public class PsbtBumpFeeOptions
    {
        public int conf_target { get; set; }
        public double fee_rate { get; set; }
        public bool replaceable { get; set; }
        public string estimate_mode { get; set; }
    }
}
