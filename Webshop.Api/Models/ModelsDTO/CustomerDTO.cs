using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Api.Models.ModelsDTO;

namespace Webshop.Api.Models.ModelDTO
{
    //A transfer object for reading a customer "CustomerDTO"
    public class CustomerDTO : UserDto
    {
        public string BillingAddress { get; set; }
        public string DefaultShippingAddress { get; set; }
        public string Country { get; set; }

        public string City { get; set; }
        public string ZipCode { get; set; }

        public List<Order> Orders { get; set; }

        public CustomerDTO()
        {

        }
        public CustomerDTO(Customer c)
        {
            BillingAddress = c.BillingAddress;
            DefaultShippingAddress = c.DefaultShippingAddress;
            Country = c.Country;

            City = c.City;
            ZipCode = c.ZipCode;
            Orders = c.Orders;
        }
    }
}