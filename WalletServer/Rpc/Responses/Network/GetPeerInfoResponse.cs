using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.Network
{
    public class BytessentPerMsg
    {
        public double msg { get; set; }
    }

    public class BytesrecvPerMsg
    {
        public int msg { get; set; }
    }

    public class GetPeerInfoResponse
    {
        public int id { get; set; }
        public string addr { get; set; }
        public string addrbind { get; set; }
        public string addrlocal { get; set; }
        public string network { get; set; }
        public int mapped_as { get; set; }
        public string services { get; set; }
        public List<string> servicesnames { get; set; }
        public bool relaytxes { get; set; }
        public int lastsend { get; set; }
        public int lastrecv { get; set; }
        public int last_transaction { get; set; }
        public int last_block { get; set; }
        public double bytessent { get; set; }
        public double bytesrecv { get; set; }
        public int conntime { get; set; }
        public double timeoffset { get; set; }
        public double pingtime { get; set; }
        public double minping { get; set; }
        public double pingwait { get; set; }
        public double version { get; set; }
        public string subver { get; set; }
        public bool inbound { get; set; }
        public bool addnode { get; set; }
        public string connection_type { get; set; }
        public double startingheight { get; set; }
        public double banscore { get; set; }
        public double synced_headers { get; set; }
        public double synced_blocks { get; set; }
        public List<double> inflight { get; set; }
        public bool whitelisted { get; set; }
        public List<string> permissions { get; set; }
        public double minfeefilter { get; set; }
        public BytessentPerMsg bytessent_per_msg { get; set; }
        public BytesrecvPerMsg bytesrecv_per_msg { get; set; }
    }
}
