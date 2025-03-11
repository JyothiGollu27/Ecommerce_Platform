using Ecommerce_Platform.Models;
using Ecommerce_Platform.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _AdminRepository;

        public AdminController(IAdmin AdminRepository)
        {
            _AdminRepository = AdminRepository;
        }
        [HttpPost]
        public ActionResult<Product> PostAdmin(Admin admin)
        {
            _productRepository.Add(product);
            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

    }
}
