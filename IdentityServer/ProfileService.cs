using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer.Db;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Merchant.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer
{
    public class ProfileService : IProfileService
    {
        protected UserManager<AppUser> UserManager;
        public ProfileService(UserManager<AppUser> userManager)
        {
            UserManager = userManager;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var appUser = await UserManager.GetUserAsync(context.Subject);
            var claims = new List<Claim>
            {
                new Claim("wallet_id", appUser.Uuid),
                new Claim("username", appUser.UserName)
            };
            context.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await UserManager.GetUserAsync(context.Subject);

            context.IsActive = (user != null);
        }
    }
}
