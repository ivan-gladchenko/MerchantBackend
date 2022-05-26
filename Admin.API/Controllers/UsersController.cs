using Admin.API.Models.Dto;
using Merchant.Core;
using Merchant.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin.API.Controllers
{
    [Route("api/[controller]")]
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
        public ActionResult DeleteUser(long id)
        {
            var user = _context.MerchantUsers.FirstOrDefault(o => o.Id == id);
            if (user == null)
                return NotFound();
            _context.MerchantUsers.Remove(user);
            return Ok();
        }
    }
}
