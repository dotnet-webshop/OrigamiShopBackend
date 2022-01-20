using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Webshop.Api.Models.ModelsDTO
{
    public class OrderCreateDTO
    {
        [Required]
        public string CustomerId { get; set; }
        [Required]
        public List<OrderDetailsCreateDto> Products { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        public string ShippingAddress { get; set; }

        public string OrderAddress { get; set; }

        public string OrderEmail { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; }

        public OrderCreateDTO()
        {

        }
        
    }    
}
