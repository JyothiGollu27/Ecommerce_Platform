using Ecommerce_Platform.Models;
using Ecommerce_Platform.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ecommerce_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _userRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userRepository.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            _userRepository.Add(user);
            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _userRepository.Update(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userRepository.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepository.Remove(id);
            return NoContent();
        }
    }
}