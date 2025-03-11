using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Platform.Models
{
    public class Product
    {
        [Key]
       public int ProductId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<CartItem> ?CartItems { get; set; }
    }
}
