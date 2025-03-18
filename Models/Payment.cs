using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Platform.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int OrderId { get; set; } // Foreign key to Order
        public string PaymentMethod { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public Order? Order { get; set; } // Navigation property for Order
    }
}
