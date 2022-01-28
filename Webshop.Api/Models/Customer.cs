using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webshop.Api.Models
{
    public class Customer : ApplicationUser
    {
        public string Username { get; set; }
        public string BillingAddress { get; set; }
        public string DefaultShippingAddress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}