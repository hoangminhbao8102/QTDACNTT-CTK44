using CarStoreAPI.Data.Contexts;
using CarStoreAPI.Models.Entities;
using CarStoreAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarStoreAPI.Repositories.Class
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;
        public ReviewRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Review>> GetAllAsync() =>
            await _context.Reviews.Include(r => r.User).Include(r => r.Car).ToListAsync();

        public async Task<Review?> GetByIdAsync(int id) =>
            await _context.Reviews.Include(r => r.User).Include(r => r.Car)
                                  .FirstOrDefaultAsync(r => r.Id == id);

        public async Task<IEnumerable<Review>> GetReviewsByCarAsync(int carId) =>
            await _context.Reviews.Where(r => r.CarId == carId)
                                  .Include(r => r.User)
                                  .ToListAsync();

        public async Task AddAsync(Review review) { _context.Reviews.Add(review); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Review review) { _context.Reviews.Update(review); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Reviews.FindAsync(id);
            if (entity != null) { _context.Reviews.Remove(entity); await _context.SaveChangesAsync(); }
        }
    }
}
