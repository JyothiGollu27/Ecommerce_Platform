using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Platform.Models
{
    public class CartItem
    {
        private int productId;

        public int CartItemId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double TotalPrice { get; set; }

        public Product ?Product { get; set; }

    }
}
