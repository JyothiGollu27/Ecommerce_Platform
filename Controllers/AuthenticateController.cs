using Ecommerce_Platform.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private UserDbContext userDbContext;
        public AuthenticateController(IConfiguration configuration, UserDbContext productManagementDbContext)
        {
            Configuration = configuration;
            this.userDbContext = productManagementDbContext;
        }

        public IConfiguration Configuration { get; }

        public IActionResult Post([FromBody] User user)
        {
            var serverSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:ServerSecret"]));

            User userFound = this.userDbContext.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();

            if (userFound != null)
            {
                var result = new
                {
                    token = GenerateToken(serverSecret, userFound)
                };
                return Ok(result);//status code
            }
            return BadRequest("Invalid Email/Password");//status code
        }


        private string GenerateToken(SecurityKey key, User user)
        {
            var now = DateTime.UtcNow;
            var issuer = Configuration["JWT:Issuer"];
            var audience = Configuration["JWT:Audience"];
            var identity = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role),
                        //new Claim(ClaimTypes.Name, user.Id.ToString())
                });
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateJwtSecurityToken(issuer, audience, identity,
            now, now.Add(TimeSpan.FromHours(1)), now, signingCredentials);
            var encodedJwt = handler.WriteToken(token);
            return encodedJwt;
        }
    }
}
