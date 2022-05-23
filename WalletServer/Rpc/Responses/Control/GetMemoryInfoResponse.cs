namespace WalletServer.Rpc.Responses.Control
{
   public class Locked
    {
        public double used { get; set; }
        public double free { get; set; }
        public double total { get; set; }
        public double locked { get; set; }
        public double chunks_used { get; set; }
        public double chunks_free { get; set; }
    }

    public class GetMemoryInfoResponse
    {
        public Locked locked { get; set; }
    }
}
