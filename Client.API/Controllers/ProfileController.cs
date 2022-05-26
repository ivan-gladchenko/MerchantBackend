using System;
using System.Linq;
using System.Threading.Tasks;
using Client.API.Models.Profile;
using Client.API.Models.Profile.Dto;
using Merchant.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Client.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProfileController : Controller
    {
        private readonly MerchantDbContext _context;
        private string _username;

        public ProfileController(MerchantDbContext context)
        {
            _context = context;

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _username = context.HttpContext.User.Claims.ToList().First(a => a.Type == "username").Value;
            base.OnActionExecuting(context);
        }

        [HttpGet]
        public async Task<UserProfileDto> Get()
        {
            var user = await _context.MerchantUsers.FirstOrDefaultAsync(o => o.AppUserName == _username);
            return new UserProfileDto(user);
        }

        [HttpPost("webhook")]
        public async Task<UserProfileDto> Webhook(WebhookSetModel model)
        {
            var user = await _context.MerchantUsers.FirstOrDefaultAsync(o => o.AppUserName == _username);
            user.WebhookAddress = model.Address;
            user = _context.MerchantUsers.Update(user).Entity;
            await _context.SaveChangesAsync();
            return new UserProfileDto(user);
        }

        [HttpPost("api-key")]
        public async Task<UserProfileDto> ApiKey()
        {
            var user = await _context.MerchantUsers.FirstOrDefaultAsync(o => o.AppUserName == _username);
            user.ApiKey = Guid.NewGuid().ToString("N");
            user = _context.MerchantUsers.Update(user).Entity;
            await _context.SaveChangesAsync();
            return new UserProfileDto(user);
        }
    }
}
