namespace Webshop.Api.Models
{
    public class ProductOptions
    {
        public int OptionId { get; set; }

        public Option Option { get; set; }


        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}