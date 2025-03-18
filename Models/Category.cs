using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Platform.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
