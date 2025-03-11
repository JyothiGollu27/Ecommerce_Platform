using Ecommerce_Platform.Models;

namespace Ecommerce_Platform.Repository
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly UserDbContext _db;

        public CartItemRepository(UserDbContext db)
        {
            _db = db;
        }

        public CartItem Add(CartItem cartItem)
        {
            _db.CartItems.Add(cartItem);
            _db.SaveChanges();
            return cartItem;
        }

        public CartItem Find(int id)
        {
            return _db.CartItems.FirstOrDefault(ci => ci.CartItemId == id);
        }

        public List<CartItem> GetAll()
        {
            return _db.CartItems.ToList();
        }

        public void Remove(int id)
        {
            CartItem cartItem = _db.CartItems.FirstOrDefault(ci => ci.CartItemId == id);
            _db.CartItems.Remove(cartItem);
            _db.SaveChanges();
        }

        public CartItem Update(CartItem cartItem)
        {
            _db.CartItems.Update(cartItem);
            _db.SaveChanges();
            return cartItem;
        }
    }
}
