using System.Collections.Generic;

namespace WalletServer.Rpc.Entities.Wallet
{
    public class SendOptions
    {
        public bool add_inputs { get; set; }
        public bool add_to_wallet { get; set; }
        public string change_address { get; set; }
        public int change_position { get; set; }
        public string change_type { get; set; }
        public int conf_target { get; set; }
        public string estimate_mode { get; set; }
        public double fee_rate { get; set; }
        public bool include_watching { get; set; }
        public List<object> inputs { get; set; }
        public int locktime { get; set; }
        public bool lock_unspents { get; set; }
        public bool psbt { get; set; }
        public List<int> subtract_fee_from_outputs { get; set; }
        public bool replaceable { get; set; }
    }
}
