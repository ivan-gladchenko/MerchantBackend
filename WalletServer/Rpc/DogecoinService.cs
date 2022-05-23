namespace WalletServer.Rpc
{
    public class DogecoinService : CoreService
    {
        public DogecoinService(string address, string login, string password) : base(address, login, password)
        {

        }

        public DogecoinService(string address) : base(address)
        {

        }
        public DogecoinService(string address, string login, string password, string wallet) : base(address, wallet,
            login, password)
        {

        }
    }

}
