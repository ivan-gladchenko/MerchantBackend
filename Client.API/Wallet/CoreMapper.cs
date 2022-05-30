using System.Collections.Generic;
using Client.API.Models;

namespace Client.API.Wallet
{
    public class CoreMapper : MapperBase<ListTransactionsResponse, MappedTransaction>
    {
        public override MappedTransaction Map(ListTransactionsResponse element, Crypto crypto)
        {
            return new MappedTransaction
            {
                Address = element.address,
                Value = element.amount,
                Confirmations = element.confirmations,
                Date = UnixTimeStampToDateTime(element.time),
                Crypto = crypto,
                @in = element.category == "receive",
                Txid = element.txid
            };
        }

        public static List<MappedTransaction> Process(List<ListTransactionsResponse> transactions, Crypto crypto)
        {
            CoreMapper mapper = new CoreMapper();
            return mapper.Map(transactions, crypto);
        }
    }
}
