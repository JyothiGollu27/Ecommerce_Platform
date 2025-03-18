using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Platform.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}
