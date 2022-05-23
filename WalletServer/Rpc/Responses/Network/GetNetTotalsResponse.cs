namespace WalletServer.Rpc.Responses.Network
{
   public class Uploadtarget
    {
        public int timeframe { get; set; }
        public int target { get; set; }
        public bool target_reached { get; set; }
        public bool serve_historical_blocks { get; set; }
        public int bytes_left_in_cycle { get; set; }
        public int time_left_in_cycle { get; set; }
    }

    public class GetNetTotalsResponse
    {
        public int totalbytesrecv { get; set; }
        public int totalbytessent { get; set; }
        public int timemillis { get; set; }
        public Uploadtarget uploadtarget { get; set; }
    }
}
