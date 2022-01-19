namespace Webshop.Api.Models.ModelDTO
{
    public class ProductCreateDTO
    {
        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public string ProductDescription { get; set; }

        public string ProductImageUrl { get; set; }

        public string DateCreated { get; set; }

        public int Stock { get; set; }

        public ProductCreateDTO() { }
    }
}
