using System;

namespace Webshop.Api.Models.ModelDTO
{
    //A transfer object for reading a product "ProductDTO"
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string PriceString { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }

        public string ShortDescription { get; set; }
        public string ProductImageUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public int Stock { get; set; }
        public double Tax { get; set; }

        public ProductDTO()
        {

        }

        public ProductDTO(Product p)
        {
            Id = p.Id;
            ProductName = p.ProductName;
            ProductPrice = p.ProductPrice;
            ProductDescription = p.ProductDescription;

            PriceString = string.Format("{0:C}", p.ProductPrice);
            ShortDescription = p.ProductDescription.Length <= 25 ? p.ProductDescription : p.ProductDescription.Substring(0, 25);
            Tax = p.ProductPrice * 0.25;
        }
    }
}
