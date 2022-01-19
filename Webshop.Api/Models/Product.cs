using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webshop.Api.Models
{
    public class Product
    {
        [Key] public int Id { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public string ProductDescription { get; set; }

        public string ProductImageUrl { get; set; }
        
        public DateTime DateCreated { get; set; }

        public int Stock { get; set; }


        public List<OrderDetails> Orders { get; set; }
        public List<ProductOptions> Options { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
