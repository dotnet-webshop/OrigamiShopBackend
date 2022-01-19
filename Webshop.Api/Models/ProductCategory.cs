﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopApp.Models
{
    [Table("ProductCategories")]
    public class ProductCategory
    {       
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
