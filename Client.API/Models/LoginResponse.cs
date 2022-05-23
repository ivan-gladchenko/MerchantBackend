using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.API.Models
{
    public class LoginResponse
    {
        public string accessToken { get; set; }
        public long expireTime { get; set; }
        public string error { get; set; }
    }
}
