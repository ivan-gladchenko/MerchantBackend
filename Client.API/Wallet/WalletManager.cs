using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Client.API.Models;
using Merchant.Core;
using Merchant.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Client.API.Wallet
{
    public class WalletManager
    {
        private HttpClient walletClient;
        private string url;
        private CryptoName crypto;

        public WalletManager(HttpClient walletClient, CryptoName crypto)
        {
            this.walletClient = walletClient;
            this.crypto = crypto;
            url += $"http://127.0.0.1:5030/api/wallet/{crypto}/";
        }

        public WalletManager(CryptoName crypto, string id)
        {
            walletClient = new HttpClient();
            this.crypto = crypto;
            url += $"http://127.0.0.1:5030/api/client/{crypto}/address?id={id}";
        }

        public async Task<string> GetNewAddress()
        {
            return await walletClient.GetStringAsync(url);
        }

        public static async Task<KeyValuePair<double, double>> GetPrices()
        {
            var client = new HttpClient();
            var response = await 
                client.GetAsync(
                    "https://api.nomics.com/v1/currencies/ticker?key=bd91392d73c2c3c1ea4acdd9fc0d82d26f4ddae6&ids=BTC,LTC&convert=UAH&interval=1d");
            var jArray = JArray.Parse(await response.Content.ReadAsStringAsync());
            double btc = 0, ltc = 0;
            foreach (var item in jArray)
            {
                if (item.Value<string>("id") == "BTC")
                {
                    btc = item["price"]?.ToObject<double>() ?? 0;
                }
                if (item.Value<string>("id") == "LTC")
                {
                    ltc = item["price"]?.ToObject<double>() ?? 0;
                }
            }
            return new KeyValuePair<double, double>(Math.Round(btc, 2), Math.Round(ltc, 2));
        }

        public async Task<double> GetBalance()
        {
            var resp = await walletClient.GetAsync(new Uri(url + "balance"));
            string text = await resp.Content.ReadAsStringAsync();
            return double.Parse(text);
        }
        public async Task<string> CreateAddress()
        {
            var resp = await walletClient.GetAsync(new Uri(url + "create/address"));
            string text = await resp.Content.ReadAsStringAsync();
            return text;
        }

        public async Task<List<MappedTransaction>> GetTransactions()
        {
            var resp = await walletClient.GetAsync(new Uri(url + "transactions"));
            string text = await resp.Content.ReadAsStringAsync();
            return CoreMapper.Process(JsonConvert.DeserializeObject<List<ListTransactionsResponse>>(text), crypto);
        }

        public async Task<string> Send(SendCryptoModel model)
        {
            var resp = await walletClient.PostAsync(new Uri(url + "send"),
                new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, MediaTypeNames.Application.Json));
            if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(await resp.Content.ReadAsStringAsync());
            }
            return await resp.Content.ReadAsStringAsync();
        }
    }
}
