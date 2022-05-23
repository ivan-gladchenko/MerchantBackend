namespace WalletServer.Rpc
{
    public class LitecoinService : CoreService
    {
        public LitecoinService(string address, string login, string password) : base(address, login, password)
        {

        }

        public LitecoinService(string address) : base(address)
        {

        }
        public LitecoinService(string address, string login, string password, string wallet) : base(address, wallet,
            login, password)
        {

        }
    }
}
