using Merchant.Core.Models;

namespace Merchant.Core
{
    public abstract class MapperBase<TFirst, TSecond>
    {
        public abstract TSecond Map(TFirst element, CryptoName crypto);


        public List<TSecond> Map(List<TFirst> elements, CryptoName crypto, Action<TSecond> callback = null)
        {
            var objectCollection = new List<TSecond>();

            if (elements != null)
            {
                foreach (TFirst element in elements)
                {
                    TSecond newObject = Map(element, crypto);
                    if (newObject != null)
                    {
                        callback?.Invoke(newObject);
                        objectCollection.Add(newObject);
                    }
                }
            }
            return objectCollection;
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
            return dateTime;
        }
    }
}
