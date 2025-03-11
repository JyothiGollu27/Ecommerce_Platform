using Ecommerce_Platform.Models;

namespace Ecommerce_Platform.Repository
{
    public class AdminRepository: IAdmin
    {
        private readonly UserDbContext _db;

        public AdminRepository(UserDbContext db)
        {
            _db = db;
        }

        public Admin Add(Admin admin)
        {
            _db.Admins.Add(admin);
            _db.SaveChanges();
            return admin;
        }

        public Admin GetAll(Admin admin)
        {
            throw new NotImplementedException();
        }
    }
}
