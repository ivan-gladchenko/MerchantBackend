using System.Net.Mime;
using System.Text;
using IdentityModel.Client;
using Merchant.API.Models;
using Merchant.Core;
using Merchant.Core.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Merchant.API.Wallet
{
    public class TransactionsHandler
    {
        private HttpClient _httpClient;
        private readonly MerchantDbContext _context;

        public TransactionsHandler(MerchantDbContext context)
        {
            _context = context;
            _httpClient = new HttpClient();
        }

        private async Task SetBearer()
        {
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

        public async Task CheckTransactions()
        {
            await CheckCreated();
            await CheckPaid();
        }

        private async Task CheckPaid()
        {
            var transactions = Get(TransactionStatus.Paid);
            var uniqueUsers = transactions.DistinctBy(o => o.MerchantUserId).Select(o => o.MerchantUserId);
            foreach (var uniqueUser in uniqueUsers)
            {
                var merchUser = _context.MerchantUsers.First(o => o.Id == uniqueUser);
                var user = _context.Users.First(o => o.UserName == merchUser.AppUserName);
                var merchantTransactions = transactions.FindAll(o => o.MerchantUserId == uniqueUser);
                var mappedTransactions = new List<MappedTransaction>();
                var cryptos = merchantTransactions.DistinctBy(o => o.Crypto).Select(o => o.Crypto);
                foreach (var crypto in cryptos)
                {
                    mappedTransactions = await AddTransactions(mappedTransactions, crypto, user.Uuid);
                }

                foreach (var merchantTransaction in merchantTransactions)
                {
                    var transaction = mappedTransactions.FirstOrDefault(o => o.Txid == merchantTransaction.Txid);
                    if (transaction?.Confirmations > 0)
                    {
                        if (!await PostWebhook(merchUser.WebhookAddress, merchantTransaction.ProductId, "Confirmed"))
                            continue;
                        merchantTransaction.MakeConfirmed();
                        _context.MerchantTransactions.Update(merchantTransaction);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCreated()
        {
            var transactions = Get(TransactionStatus.Created);
            var uniqueUsers = transactions.DistinctBy(o => o.MerchantUserId).Select(o => o.MerchantUserId);
            foreach (var uniqueUser in uniqueUsers)
            {
                var merchUser = _context.MerchantUsers.First(o => o.Id == uniqueUser);
                var user = _context.Users.First(o => o.UserName == merchUser.AppUserName);
                var merchantTransactions = transactions.FindAll(o => o.MerchantUserId == uniqueUser);
                var mappedTransactions = new List<MappedTransaction>();
                var cryptos = merchantTransactions.DistinctBy(o => o.Crypto).Select(o => o.Crypto);
                foreach (var crypto in cryptos)
                {
                    mappedTransactions = await AddTransactions(mappedTransactions, crypto, user.Uuid);
                }
                foreach (var merchantTransaction in merchantTransactions)
                {
                    if (merchantTransaction.ExpiresAt <= DateTime.UtcNow)
                    {
                        await PostWebhook(merchUser.WebhookAddress, merchantTransaction.ProductId, "Expired");
                        merchantTransaction.MakeExpired();
                        _context.MerchantTransactions.Update(merchantTransaction);
                        continue;
                    }

                    var mappedTransaction = mappedTransactions.FirstOrDefault(o =>
                        o.@in && o.Address == merchantTransaction.Address &&
                        Math.Abs(o.Value - merchantTransaction.Value) < 0.0000001);
                    if (mappedTransaction == null) continue;
                    merchantTransaction.MakePaid(mappedTransaction.Txid);
                    _context.MerchantTransactions.Update(merchantTransaction);
                }
                await _context.SaveChangesAsync();
            }

        }

        private async Task<bool> PostWebhook(string webhookAddress, string productId, string status)
        {
            var obj = new WebhookDto
            {
                ProductId = productId,
                Status = status
            };
            try
            {
                var res = await new HttpClient().PostAsync(webhookAddress,
                    new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, MediaTypeNames.Application.Json));
                return res.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        private async Task<List<MappedTransaction>> AddTransactions(List<MappedTransaction> mappedTransactions, CryptoName crypto, string id)
        {
            var coreTransactions = await GetTransactions(crypto, id);
            if (coreTransactions?.Count > 0)
            {
                mappedTransactions.AddRange(CoreMapper.Process(coreTransactions, crypto));
            }
            return mappedTransactions;
        }

        private List<MerchantTransaction> Get(TransactionStatus status)
        {
            return _context.MerchantTransactions.Where(x => x.Status == status).ToList();
        }

    }
}
