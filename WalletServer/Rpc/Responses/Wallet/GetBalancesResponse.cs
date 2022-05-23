namespace WalletServer.Rpc.Responses.Wallet
{
    public class GetBalancesResponse
    {
        public BalancesInfo mine { get; set; }
        public BalancesInfo watchonly { get; set; }


        public class BalancesInfo
        {
            public double trusted { get; set; }
            public double untrusted_pending { get; set; }
            public double immature { get; set; }
            public double used { get; set; }
        }
    }
}
