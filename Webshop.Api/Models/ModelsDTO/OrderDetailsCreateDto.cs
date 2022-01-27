using System.ComponentModel.DataAnnotations;

namespace Webshop.Api.Models.ModelsDTO
{
    public class OrderDetailsCreateDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}