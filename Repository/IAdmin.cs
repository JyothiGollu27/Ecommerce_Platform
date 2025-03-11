using Ecommerce_Platform.Models;

namespace Ecommerce_Platform.Repository
{
    public interface IAdmin
    {
        Admin Add(Admin admin);
        Admin GetAll(Admin admin);
    }
}

