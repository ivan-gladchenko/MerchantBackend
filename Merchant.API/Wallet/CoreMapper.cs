using Merchant.Core;
using Merchant.Core.Models;

namespace Merchant.API.Wallet
{
    public class CoreMapper : MapperBase<CoreTransaction, MappedTransaction>
    {
        public override MappedTransaction Map(CoreTransaction element, CryptoName crypto)
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

        public static List<MappedTransaction> Process(List<CoreTransaction> transactions, CryptoName crypto)
        {
            CoreMapper mapper = new CoreMapper();
            return mapper.Map(transactions, crypto);
        }
    }
}
