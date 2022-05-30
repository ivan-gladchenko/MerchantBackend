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
        private HttpClient _httpClient = new();

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
            var jsonToken = await HttpContext.GetTokenAsync("access_token");
            _httpClient.SetBearerToken(jsonToken);
            var resp = await _httpClient.DeleteAsync($"http://127.0.0.1:2000/api/Users/{user.AppUserName}");
            if (!resp.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            _context.MerchantUsers.Remove(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
