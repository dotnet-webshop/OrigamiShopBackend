using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApp.Models.JwtModels
{
    public class AuthenticationResult
    {
        public String Token { get; set; }
        public bool Success { get; set; }
        public List<String> Errors { get; set; }
    }
}
