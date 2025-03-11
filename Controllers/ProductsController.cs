using Ecommerce_Platform.Models;
using Ecommerce_Platform.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ecommerce_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return _productRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productRepository.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            _productRepository.Add(product);
            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _productRepository.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productRepository.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _productRepository.Remove(id);
            return NoContent();
        }
    }
}