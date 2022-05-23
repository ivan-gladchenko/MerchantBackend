namespace WalletServer.Rpc
{
    public class BitcoinService : CoreService
    {
        public BitcoinService(string address, string login, string password) :base(address, login, password)
        {
            
        }

        public BitcoinService(string address):base(address)
        {
            
        }

        public BitcoinService(string address, string login, string password, string wallet) : base(address, wallet,
            login, password)
        {

        }
    }
}
