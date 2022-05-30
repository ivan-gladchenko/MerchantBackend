using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Merchant.Core.Models
{
    public class AppUser : IdentityUser
    {
        [Key]
        public override string Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Uuid { get; set; }
        public string Role { get; set; }
        
    }
}
