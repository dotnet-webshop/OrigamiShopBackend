using Microsoft.AspNetCore.Identity;

namespace Webshop.Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        //public string UserName { get; set; }
    }
}