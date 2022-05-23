using System.Collections.Generic;

namespace WalletServer.Rpc.Entities.RawTransactions
{
    public class RawTransactionOptions
    {
        public bool add_inputs { get; set; }
        public string changeAddress { get; set; }
        public int changePosition { get; set; }
        public string change_type { get; set; }
        public bool includeWatching { get; set; }
        public bool lockUnspents { get; set; }
        public double fee_rate { get; set; }
        public double feeRate { get; set; }
        public List<int> subtractFeeFromOutputs { get; set; }
        public bool replaceable { get; set; }
        public int conf_target { get; set; }
        public string estimate_mode { get; set; }
    }
}
