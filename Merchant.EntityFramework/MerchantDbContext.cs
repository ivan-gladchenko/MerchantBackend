using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merchant.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Merchant.Core
{
    public class MerchantDbContext : DbContext
    {
        public DbSet<MerchantTransaction> MerchantTransactions { get; set; }
        public DbSet<MerchantUser> MerchantUsers { get; set; }
        public MerchantDbContext(DbContextOptions<MerchantDbContext> options) : base(options)
        {
            
        }
    }
}
