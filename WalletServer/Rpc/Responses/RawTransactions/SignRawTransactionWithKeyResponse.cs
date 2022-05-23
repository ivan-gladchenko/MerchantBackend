using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.RawTransactions
{
    public class Error
    {
        public string txid { get; set; }
        public int vout { get; set; }
        public string scriptSig { get; set; }
        public int sequence { get; set; }
        public string error { get; set; }
    }

    public class SignRawTransactionWithKeyResponse
    {
        public string hex { get; set; }
        public bool complete { get; set; }
        public List<Error> errors { get; set; }
    }
}
