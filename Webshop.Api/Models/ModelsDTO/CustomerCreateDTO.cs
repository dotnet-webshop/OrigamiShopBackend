using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Webshop.Api.Models.ModelsDTO
{
    public class CustomerCreateDTO
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FullName { get; set; }
        [Required]
        public string BillingAddress { get; set; }
        [Required]
        public string DefaultShippingAddress { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string ZipCode { get; set; }
        
        public CustomerCreateDTO()
        {

        }
        public CustomerCreateDTO(Customer c)
        {
            BillingAddress = c.BillingAddress;
            DefaultShippingAddress = c.DefaultShippingAddress;
            Country = c.Country;
            City = c.City;
            ZipCode = c.ZipCode;
        }
       
    }
}
