using System.Text.Json;
using IdentityModel.Client;
using Merchant.Core.Models;

namespace Merchant.API.Wallet
{
    public class TransactionsHandler
    {
        private HttpClient _httpClient;

        private async Task SetBearer()
        {
            _httpClient = new HttpClient();
            var discoveryDocument = await _httpClient.GetDiscoveryDocumentAsync("http://127.0.0.1:2000");
            if (discoveryDocument.IsError)
            {
                return;
            }

            var token = await _httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = "merchant_client",
                ClientSecret = "merchant_secret_key",
                Scope = "WalletServer"
            });
            _httpClient = new HttpClient();
            _httpClient.SetBearerToken(token.AccessToken);
        }

        public async Task<List<CoreTransaction>?> GetTransactions(CryptoName cryptoName, string walletId)
        {
            await SetBearer();
            return JsonSerializer.Deserialize<List<CoreTransaction>>(
                await _httpClient.GetStringAsync(
                    new Uri($"http://127.0.0.1:5030/api/merchant/{cryptoName}?wallet={walletId}")));
        }
    }
}
