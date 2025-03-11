using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Platform.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string ShippingAddress { get; set; }

        public string PaymentDetails { get; set; }

        public ICollection<Order> ?Orders { get; set; }
    }
}
