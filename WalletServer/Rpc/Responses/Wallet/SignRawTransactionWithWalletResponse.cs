using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.Wallet
{
    public class SignRawTransactionWithWalletResponse
    {
        public string hex { get; set; }
        public bool complete { get; set; }
        public List<SignRawTransactionWithWalletError> errors { get; set; }
    }
    public class SignRawTransactionWithWalletError
    {
        public string txid { get; set; }
        public int vout { get; set; }
        public string scriptSig { get; set; }
        public int sequence { get; set; }
        public string error { get; set; }
    }
}
