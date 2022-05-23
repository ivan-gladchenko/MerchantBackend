using System.Collections.Generic;
using WalletServer.Rpc.Responses.RawTransactions;

namespace WalletServer.Rpc.Responses.Blockchain
{
    public class GetBlockVerbosity2Response : GetBlockVerbosity1Response
    {
        public List<RawTransactionResponse> txs { get; set; }
    }
}
