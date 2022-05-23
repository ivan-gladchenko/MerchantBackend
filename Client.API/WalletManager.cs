using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Client.API.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;

namespace Client.API
{
    public class WalletManager
    {
        private HttpClient walletClient;
        private string url;
        private Crypto crypto;

        public WalletManager(HttpClient walletClient, Crypto crypto)
        {
            this.walletClient = walletClient;
            this.crypto = crypto;
            url += $"http://127.0.0.1:5030/api/wallet/{crypto}/";
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
