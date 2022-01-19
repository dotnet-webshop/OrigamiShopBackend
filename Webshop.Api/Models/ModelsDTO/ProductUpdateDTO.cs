
namespace WebShopApp.Models.ModelDTO
{
    public class ProductUpdateDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public string ProductDescription { get; set; }

        public string ProductImageUrl { get; set; }
        
        public int Stock { get; set; }

        public ProductUpdateDTO()
        {

        }
    }
}
