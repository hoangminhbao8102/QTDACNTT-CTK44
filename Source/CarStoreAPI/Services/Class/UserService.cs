using CarStoreAPI.Data.Contexts;
using CarStoreAPI.Models.DTO;
using CarStoreAPI.Models.Entities;
using CarStoreAPI.Repositories.Interface;
using CarStoreAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarStoreAPI.Services.Class
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository, AppDbContext context)
        { 
            _repository = repository; 
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync() => await _repository.GetAllAsync();
        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Where(u => u.Id == id)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Email = u.Email,
                    Username = u.Username,
                    Role = u.Role,
                    CreatedAt = u.CreatedAt
                })
                .FirstOrDefaultAsync();
        }
        public async Task<User?> GetUserByEmailAsync(string email) => await _repository.GetByEmailAsync(email);
        public async Task AddUserAsync(User user) => await _repository.AddAsync(user);
        public async Task UpdateUserAsync(User user) => await _repository.UpdateAsync(user);
        public async Task DeleteUserAsync(int id) => await _repository.DeleteAsync(id);
    }
}
