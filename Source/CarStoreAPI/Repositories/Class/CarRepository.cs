using CarStoreAPI.Data.Contexts;
using CarStoreAPI.Models.Entities;
using CarStoreAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarStoreAPI.Repositories.Class
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Cars.Include(c => c.Category).ToListAsync();
        }

        public async Task<Car?> GetByIdAsync(int id)
        {
            return await _context.Cars
                .Include(c => c.Category)
                .Include(c => c.Images)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Car>> GetCarsByCategoryAsync(int categoryId)
        {
            return await _context.Cars
                .Where(c => c.CategoryId == categoryId)
                .Include(c => c.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Car>> SearchCarsAsync(string keyword)
        {
            return await _context.Cars
                .Where(c => c.Name.Contains(keyword) || c.Description.Contains(keyword))
                .Include(c => c.Category)
                .ToListAsync();
        }
    }
}
