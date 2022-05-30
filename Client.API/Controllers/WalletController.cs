using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Client.API.Models;
using Client.API.Wallet;
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
        private readonly WalletManager _walletManager;

        public WalletController(WalletManagerHandler walletManagerHandler)
        {
            _walletManager = walletManagerHandler.WalletManager;
        }
        
        [HttpGet("balance")]
        public async Task<double> GetBalance()
        {
           return await _walletManager.GetBalance();
        }

        [HttpGet("address")]
        public async Task<string> CreateAddress()
        {
            return await _walletManager.CreateAddress();
        }

        [HttpGet("transactions")]
        public async Task<List<MappedTransaction>> GetTransactions()
        {
            return await _walletManager.GetTransactions();
        }

        [HttpPost("send")]
        public async Task<string> Send(SendCryptoModel model)
        {
            try
            {
                return await _walletManager.Send(model);
            }
            catch (Exception e)
            {
                Response.StatusCode = 400;
                return e.Message;
            }
        }
    }
}
