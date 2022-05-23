namespace WalletServer.Rpc.Entities.Wallet
{
    public class ImportDescriptorsObject
    {
        public string desc { get; set; }
        public bool active { get; set; }
        public object range { get; set; }
        public int next_index { get; set; }
        public object timestamp { get; set; }
        public bool @internal { get; set; }
        public string label { get; set; }
    }
}
