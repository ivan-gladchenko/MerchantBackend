using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.API.Models;

namespace Client.API
{
    public abstract class MapperBase<TFirst, TSecond>
    {
        public abstract TSecond Map(TFirst element, Crypto crypto);


        public List<TSecond> Map(List<TFirst> elements, Crypto crypto, Action<TSecond> callback = null)
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
