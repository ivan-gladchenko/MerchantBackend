using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Client.API.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Client.API.Controllers
{
    [Route("api/[controller]/{wallet}")]
    [Authorize]
    [ApiController]
    public class WalletController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private WalletManager walletManager;

        public WalletController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var jsonToken = HttpContext.GetTokenAsync("access_token").GetAwaiter().GetResult();
            if (!Enum.TryParse((string)context.RouteData.Values.FirstOrDefault(obj => obj.Key == "wallet").Value, out Crypto wallet))
            {
                return;
            }
            var client = _httpClientFactory.CreateClient();
            client.SetBearerToken(jsonToken);
            walletManager = new WalletManager(client, wallet);
        }

        [HttpGet("balance")]
        public async Task<double> GetBalance()
        {
           return await walletManager.GetBalance();
        }

        [HttpGet("address")]
        public async Task<string> CreateAddress()
        {
            return await walletManager.CreateAddress();
        }

        [HttpGet("transactions")]
        public async Task<List<MappedTransaction>> GetTransactions()
        {
            return await walletManager.GetTransactions();
        }

        [HttpPost("send")]
        public async Task<string> Send(SendCryptoModel model)
        {
            try
            {
                return await walletManager.Send(model);
            }
            catch (Exception e)
            {
                Response.StatusCode = 400;
                return e.Message;
            }
        }
    }
}
