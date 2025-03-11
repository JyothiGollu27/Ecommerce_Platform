using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Platform.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int UserId { get; set; }
        public double TotalPrice { get; set; }
        public string ShippingAddress { get; set; }

        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public User? User { get; set; }

    }
}
