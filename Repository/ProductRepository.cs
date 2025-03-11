using Ecommerce_Platform.Models;

namespace Ecommerce_Platform.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly UserDbContext _db;

        public ProductRepository(UserDbContext db)
        {
            _db = db;
        }

        public Product Add(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return product;
        }

        public Product Find(int id)
        {
            return _db.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public List<Product> GetAll()
        {
            return _db.Products.ToList();
        }

        public void Remove(int id)
        {
            Product product = _db.Products.FirstOrDefault(p => p.ProductId == id);
            _db.Products.Remove(product);
            _db.SaveChanges();
        }

        public Product Update(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
            return product;
        }
    }
}
