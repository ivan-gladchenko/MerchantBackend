using System.Linq;
using Merchant.Core;
using Merchant.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Db
{
    public class DbInitializer
    {
        public static void Initialize(MerchantDbContext context, UserManager<AppUser> userManager)
        {
            var user = context.Users.FirstOrDefault(o => o.Role == "admin");
            if (user == null)
            {
                userManager.CreateAsync(new AppUser
                {
                    UserName = "admin",
                    Role = "admin",
                    FullName = "admin admin",
                    Uuid = "admin"
                }, "admin").GetAwaiter().GetResult();
            }
        }
    }
}
