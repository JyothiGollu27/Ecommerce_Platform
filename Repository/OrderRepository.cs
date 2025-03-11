using Ecommerce_Platform.Models;

namespace Ecommerce_Platform.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly UserDbContext _db;

        public OrderRepository(UserDbContext db)
        {
            _db = db;
        }

        public Order Add(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
            return order;
        }

        public Order Find(int id)
        {
            return _db.Orders.FirstOrDefault(o => o.OrderId == id);
        }

        public List<Order> GetAll()
        {
            return _db.Orders.ToList();
        }

        public void Remove(int id)
        {
            Order order = _db.Orders.FirstOrDefault(o => o.OrderId == id);
            _db.Orders.Remove(order);
            _db.SaveChanges();
        }

        public Order Update(Order order)
        {
            _db.Orders.Update(order);
            _db.SaveChanges();
            return order;
        }
    }
}
