using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.Network
{
    public class Network 
    {
        public string name { get; set; }
        public bool limited { get; set; }
        public bool reachable { get; set; }
        public string proxy { get; set; }
        public bool proxy_randomize_credentials { get; set; }
    }

    public class Localaddress
    {
        public string address { get; set; }
        public int port { get; set; }
        public int score { get; set; }
    }

    public class GetNetworkInfoResponse
    {
        public double version { get; set; }
        public string subversion { get; set; }
        public double protocolversion { get; set; }
        public string localservices { get; set; }
        public List<string> localservicesnames { get; set; }
        public bool localrelay { get; set; }
        public double timeoffset { get; set; }
        public int connections { get; set; }
        public int connections_in { get; set; }
        public int connections_out { get; set; }
        public bool networkactive { get; set; }
        public List<Network> networks { get; set; }
        public double relayfee { get; set; }
        public double incrementalfee { get; set; }
        public List<Localaddress> localaddresses { get; set; }
        public string warnings { get; set; }
    }
}
