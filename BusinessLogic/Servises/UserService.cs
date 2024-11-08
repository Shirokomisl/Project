using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace LampShop.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(int userId, User user)
        {
            var existingUser = await _context.Users.FindAsync(userId);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.FirstName = user.FirstName;
            existingUser.Email = user.Email;
            // Пароль (Password) не обновляем, его нужно хешировать.

            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}