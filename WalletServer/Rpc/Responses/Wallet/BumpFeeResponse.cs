using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.Wallet
{
    public class BumpFeeResponse
    {
        public string psbt { get; set; }
        public string txid { get; set; }
        public double origfee { get; set; }
        public double fee { get; set; }
        public List<string> errors { get; set; }
    }
}
