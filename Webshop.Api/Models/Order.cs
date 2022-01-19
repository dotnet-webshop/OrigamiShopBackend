using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopApp.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key] 
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
    }
}