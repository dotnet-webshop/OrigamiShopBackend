using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Api.Models.ModelsDTO
{
    public class OrderUpdateDTO
    {
        public int Id { get; set; }

        public string CustomerId { get; set; }

        public List<OrderDetailsCreateDto> Products { get; set; }

        public double TotalPrice { get; set; }

        public string ShippingAddress { get; set; }

        public string OrderAddress { get; set; }

        public string OrderEmail { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; }

        public OrderUpdateDTO()
        {
        }
    }
}