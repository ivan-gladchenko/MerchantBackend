namespace WalletServer.Rpc.Responses.Zmq
{
    public class GetZmqNotificationsResponse
    {
        public string type { get; set; }
        public string address { get; set; }
        public double hwm { get; set; }
    }
}
