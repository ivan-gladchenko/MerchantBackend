using System.Threading.Tasks;
using IdentityServer.Db;
using Merchant.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Admin")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpDelete]
        public async Task DeleteUser([FromQuery] string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            await _userManager.DeleteAsync(user);
        }
    }
}
