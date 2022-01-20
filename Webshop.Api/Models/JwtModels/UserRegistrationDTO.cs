using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Api.Models.JwtModels
{
    public class UserRegistrationDTO
    {
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }
    }
}
