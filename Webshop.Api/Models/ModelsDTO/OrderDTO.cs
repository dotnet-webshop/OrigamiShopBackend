using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApp.Models.ModelsDTO
{
    //A transfer object for reading a order "OrderDTO"
    public class OrderDTO
    {
        public int Id { get; set; }
        public string CustomerId;        
        public Customer Customer { get; set; }
        public List<OrderDetails> Products { get; set; }
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

        public OrderDTO(Order o)
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

            TotalPrice_inclTax = o.TotalPrice * 1.25;
        }
    }
}
