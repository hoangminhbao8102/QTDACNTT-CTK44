using CarStoreAPI.Data.Contexts;
using CarStoreAPI.Models.Entities;
using CarStoreAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarStoreAPI.Repositories.Class
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Category>> GetAllAsync() => await _context.Categories.ToListAsync();
        public async Task<Category?> GetByIdAsync(int id) => await _context.Categories.FindAsync(id);
        public async Task<Category?> GetByNameAsync(string name) =>
            await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
        public async Task AddAsync(Category category) { _context.Categories.Add(category); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Category category) { _context.Categories.Update(category); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Categories.FindAsync(id);
            if (entity != null) { _context.Categories.Remove(entity); await _context.SaveChangesAsync(); }
        }
    }
}
