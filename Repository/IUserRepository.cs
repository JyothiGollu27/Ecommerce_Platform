using Ecommerce_Platform.Models;

namespace Ecommerce_Platform.Repository
{
    public interface IUserRepository
    {
        User Find(int id);
        List<User> GetAll();
        User Add(User user);
        User Update(User user);
        void Remove(int id);
    }
}
