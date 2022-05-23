namespace WalletServer.Rpc.Handler
{
    class RpcBody
    {
        public string jsonrpc { get; set; }
        public string id { get; set; }
        public string method { get; set; }
        public object @params { get; set; }

        public RpcBody(string method, object paramsList)
        {
            jsonrpc = "1.0";
            id = "1";
            this.method = method;
            this.@params = paramsList;
        }
    }
}
