using GeniyIdiotWebApi.Data;
using GeniyIdiotWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GeniyIdiotWebApi.Repository
{
    public class UserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<User> SaveAsync(User user)
        {
            await _context.AddAsync<User>(user);

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                throw new Exception("Не удалось сохранить в БД. Откат");
            }

            return user;
        }
    }
}
