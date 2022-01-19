using System.ComponentModel.DataAnnotations;

namespace WebShopApp.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
