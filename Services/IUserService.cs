using Ecommerce_Platform.Models;

namespace Ecommerce_Platform.Services
{
    public interface IUserService
    {
        User Add(User user);
        User Find(int id);
        List<User> GetAll();
        void Remove(int id);
        User Update(User user);
        bool IsUserNameUnique(string userName);
        bool IsEmailUnique(string email);
    }
}
