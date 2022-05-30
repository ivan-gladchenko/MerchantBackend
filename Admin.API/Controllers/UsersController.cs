using Admin.API.Models.Dto;
using IdentityModel.Client;
using Merchant.Core;
using Merchant.Core.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MerchantDbContext _context;

        public UsersController(MerchantDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<MerchantUserDto> GetUsers()
        {
            return _context.MerchantUsers.Select(o => new MerchantUserDto(o)).ToList();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(long id)
        {
            var user = _context.MerchantUsers.FirstOrDefault(o => o.Id == id);
            if (user == null)
                return NotFound();
            _context.MerchantUsers.Remove(user);
            var appUser = _context.Users.FirstOrDefault(o => o.UserName == user.AppUserName);
            if (appUser != null)
                _context.Users.Remove(appUser);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
