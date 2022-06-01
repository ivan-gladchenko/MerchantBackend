using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WalletServer.Rpc.Handler
{
    internal class RpcHandler
    {
        private readonly NetworkCredential _credentials;
        private Uri _address;
        public RpcHandler(string address, string login, string password) : this(address)
        {
            _credentials = new NetworkCredential(login, password);
        }
        public RpcHandler(string address, string login, string password, string wallet) : this(address, wallet)
        {
            _credentials = new NetworkCredential(login, password);
        }
        public RpcHandler(string address, string wallet)
        {
            _address = new Uri($"{address}/wallet/{wallet}");
        }
        public RpcHandler(string address)
        {
            _address = new Uri(address);
        }

        public RpcResponse<T> Send<T>(string method, object parameters, bool isClear = false)
        {
            var webClient = GetClient();
            var body = new RpcBody(method, parameters);
            var json = JsonSerializer.Serialize(body);
            // if (isClear)
            // {
            //     _address = new Uri(_address.OriginalString.Split("wallet")[0]);
            // }
            try
            {
                var httpResponse = webClient.PostAsync(_address, new StringContent(json, Encoding.UTF8, "application/json-rpc")).GetAwaiter().GetResult();
                string uploadString = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var response = JsonSerializer.Deserialize<RpcResponse<T>>(uploadString);
                if (response?.error != null)
                {
                    throw new RpcException(response.error.message);
                }
                return response;
            }
            catch (WebException e)
            {
                if (e.Response == null)
                {
                    throw new RpcException(e.Message);
                }
                using var r = new StreamReader(e.Response.GetResponseStream() ?? throw new RpcException(e.Message));
                var responseContent = r.ReadToEnd();
                var resp = JsonSerializer.Deserialize<RpcResponse<string>>(responseContent);
                throw new RpcException($"{e.Message} \nError code: {resp.error.code} \nMessage: {resp.error.message}");
            }
        }

        private HttpClient GetClient()
        {

            return new HttpClient(new HttpClientHandler
            {
                Credentials = _credentials
            });
        }

        internal class RpcResponse<T>
        {
            public Error error { get; set; }
            public object id { get; set; }
            public T result { get; set; }

            internal class Error
            {
                public int code { get; set; }
                public string message { get; set; }
            }
        }
        internal class RpcException : Exception
        {
            public RpcException(string message) : base(message)
            {

            }
        }
    }
}
