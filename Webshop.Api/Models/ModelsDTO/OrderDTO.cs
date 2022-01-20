using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Api.Models.ModelDTO;

namespace Webshop.Api.Models.ModelsDTO
{
    //A transfer object for reading a order "OrderDTO"
    public class OrderDTO
    {
        public int Id { get; set; }
        public string CustomerId;
        public List<OrderDetailsDto> Products { get; set; }
        public double TotalPrice { get; set; }
        public string ShippingAddress { get; set; }
        public string OrderAddress { get; set; }
        public string OrderEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }

        public double TotalPrice_inclTax { get; set; }

        public OrderDTO()
        {

        }
        
    }
}
