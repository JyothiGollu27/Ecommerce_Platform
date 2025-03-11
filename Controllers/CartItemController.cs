using Ecommerce_Platform.Models;
using Ecommerce_Platform.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ecommerce_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemsController(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CartItem>> GetCartItems()
        {
            return _cartItemRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<CartItem> GetCartItem(int id)
        {
            var cartItem = _cartItemRepository.Find(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            return cartItem;
        }

        [HttpPost]
        public ActionResult<CartItem> PostCartItem(CartItem cartItem)
        {
            _cartItemRepository.Add(cartItem);
            return CreatedAtAction("GetCartItem", new { id = cartItem.CartItemId }, cartItem);
        }

        [HttpPut("{id}")]
        public IActionResult PutCartItem(int id, CartItem cartItem)
        {
            if (id != cartItem.CartItemId)
            {
                return BadRequest();
            }

            _cartItemRepository.Update(cartItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCartItem(int id)
        {
            var cartItem = _cartItemRepository.Find(id);
            if (cartItem == null)
            {
                return NotFound();
            }

            _cartItemRepository.Remove(id);
            return NoContent();
        }
    }
}