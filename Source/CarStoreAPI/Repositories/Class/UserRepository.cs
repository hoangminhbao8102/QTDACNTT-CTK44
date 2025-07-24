using CarStoreAPI.Data.Contexts;
using CarStoreAPI.Models.Entities;
using CarStoreAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarStoreAPI.Repositories.Class
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<User>> GetAllAsync() => await _context.Users.ToListAsync();
        public async Task<User?> GetByIdAsync(int id) => await _context.Users.FindAsync(id);
        public async Task<User?> GetByEmailAsync(string email) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        public async Task<User?> GetByUsernameAsync(string username) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        public async Task AddAsync(User user) { _context.Users.Add(user); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(User user) { _context.Users.Update(user); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Users.FindAsync(id);
            if (entity != null) { _context.Users.Remove(entity); await _context.SaveChangesAsync(); }
        }
    }
}
