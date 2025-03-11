using Ecommerce_Platform.Models;

namespace Ecommerce_Platform.Repository
{
    public interface IOrderRepository
    {
        Order Find(int id);
        List<Order> GetAll();
        Order Add(Order order);
        Order Update(Order order);
        void Remove(int id);
    }
}
