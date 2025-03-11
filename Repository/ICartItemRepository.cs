using Ecommerce_Platform.Models;

namespace Ecommerce_Platform.Repository
{
    public interface ICartItemRepository
    {
        CartItem Find(int id);
        List<CartItem> GetAll();
        CartItem Add(CartItem cartItem);
        CartItem Update(CartItem cartItem);
        void Remove(int id);
    }
}
