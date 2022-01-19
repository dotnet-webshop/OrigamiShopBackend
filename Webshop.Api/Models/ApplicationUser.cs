using Microsoft.AspNetCore.Identity;

namespace WebShopApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        //public string UserName { get; set; }
    }
}