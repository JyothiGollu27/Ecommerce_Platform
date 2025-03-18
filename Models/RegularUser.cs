namespace Ecommerce_Platform.Models
{
    public class RegularUser : User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
