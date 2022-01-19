using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApp.Models.ModelsDTO
{
    public class OrderCreateDTO
    {
        public int Id { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<OrderDetails> Products { get; set; }

        public double TotalPrice { get; set; }

        public string ShippingAddress { get; set; }

        public string OrderAddress { get; set; }

        public string OrderEmail { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; }

        public OrderCreateDTO()
        {

        }

        public OrderCreateDTO(Order o)
        {
            Id = o.Id;
            CustomerId = o.CustomerId;
            Customer = o.Customer;
            Products = o.Products;
            TotalPrice = o.TotalPrice;
            ShippingAddress = o.ShippingAddress;
            OrderAddress = o.OrderAddress;
            OrderEmail = o.OrderEmail;
            OrderDate = o.OrderDate;
            OrderStatus = o.OrderStatus;
        }
    }    
}
