using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Platform.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string Name { get; set; }

        public string Role { get; set; }

        public string Permissions { get; set; }    
    }
}
