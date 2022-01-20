using Webshop.Api.Models.ModelDTO;

namespace Webshop.Api.Models.ModelsDTO
{
    public class OrderDetailsDto
    {
        public ProductDTO Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}