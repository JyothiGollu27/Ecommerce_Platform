using Ecommerce_Platform.Models;

namespace Ecommerce_Platform.Repository
{
        public class UserRepository : IUserRepository
        {
            private readonly UserDbContext _db;

            public UserRepository(UserDbContext db)
            {
                _db = db;
            }

            public User Add(User user)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return user;
            }

            public User Find(int id)
            {
                return _db.Users.FirstOrDefault(u => u.UserId == id);
            }

            public List<User> GetAll()
            {
                return _db.Users.ToList();
            }

            public void Remove(int id)
            {
                User user = _db.Users.FirstOrDefault(u => u.UserId == id);
                _db.Users.Remove(user);
                _db.SaveChanges();
            }

            public User Update(User user)
            {
                _db.Users.Update(user);
                _db.SaveChanges();
                return user;
            }
        }
}
