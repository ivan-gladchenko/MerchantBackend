using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merchant.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
#pragma warning disable CS8618

namespace Merchant.Core
{
    public class MerchantDbContext : DbContext
    {
        public DbSet<MerchantTransaction> MerchantTransactions { get; set; }
        public DbSet<MerchantUser> MerchantUsers { get; set; }
        public DbSet<AppUser> Users { get; set; }

        public MerchantDbContext(DbContextOptions<MerchantDbContext> options) : base(options)
        {
            
        }

    }
}
