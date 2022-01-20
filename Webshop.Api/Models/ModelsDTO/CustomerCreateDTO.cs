using System;
using System.Collections.Generic;

namespace Webshop.Api.Models.ModelsDTO
{
    public class CustomerCreateDTO
    {
        public string BillingAddress { get; set; }
        public string DefaultShippingAddress { get; set; }
        public string Country { get; set; }

        public string City { get; set; }
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
