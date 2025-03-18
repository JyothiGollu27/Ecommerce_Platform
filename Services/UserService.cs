using Ecommerce_Platform.Models;
using Ecommerce_Platform.Repository;
using System.Security.Cryptography;
using System.Text;

namespace Ecommerce_Platform.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Add(User user)
        {
            try
            {
                // Validate user data
                ValidateUser(user);
                // Hash the password before saving
                user.Password = HashPassword(user.Password);
                return _userRepository.Add(user);
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework)
                Console.WriteLine($"Error adding user: {ex.Message}");
                throw new ApplicationException("An error occurred while adding the user.");
            }
        }

        public User Find(int id)
        {
            try
            {
                return _userRepository.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding user: {ex.Message}");
                throw new ApplicationException("An error occurred while finding the user.");
            }
        }

        public List<User> GetAll()
        {
            try
            {
                return _userRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all users: {ex.Message}");
                throw new ApplicationException("An error occurred while getting all users.");
            }
        }

        public void Remove(int id)
        {
            try
            {
                _userRepository.Remove(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing user: {ex.Message}");
                throw new ApplicationException("An error occurred while removing the user.");
            }
        }

        public User Update(User user)
        {
            try
            {
                // Validate user data
                ValidateUser(user);
                return _userRepository.Update(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                throw new ApplicationException("An error occurred while updating the user.");
            }
        }

        public bool IsUserNameUnique(string userName)
        {
            return !_userRepository.GetAll().Any(u => u.UserName == userName);
        }

        public bool IsEmailUnique(string email)
        {
            return !_userRepository.GetAll().Any(u => u.Email == email);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void ValidateUser(User user)
        {
            if (string.IsNullOrEmpty(user.UserName))
            {
                throw new ArgumentException("User name cannot be empty");
            }
            if (string.IsNullOrEmpty(user.Email))
            {
                throw new ArgumentException("Email cannot be empty");
            }
            if (!IsValidEmail(user.Email))
            {
                throw new ArgumentException("Invalid email format");
            }
            if (!IsUserNameUnique(user.UserName))
            {
                throw new ArgumentException("User name is already taken");
            }
            if (!IsEmailUnique(user.Email))
            {
                throw new ArgumentException("Email is already registered");
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
