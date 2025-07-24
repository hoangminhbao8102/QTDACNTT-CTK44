using CarStoreAPI.Data.Contexts;
using CarStoreAPI.Models.DTO;
using CarStoreAPI.Models.Entities;
using CarStoreAPI.Repositories.Interface;
using CarStoreAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarStoreAPI.Services.Class
{
    public class CarService : ICarService
    {
        private readonly AppDbContext _context;
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository, AppDbContext context)
        {
            _carRepository = carRepository;
            _context = context;
        }

        public async Task<IEnumerable<CarDto>> GetAllCarsAsync()
        {
            return await _context.Cars
                .Include(c => c.Category)
                .Include(c => c.Images)
                .Select(c => new CarDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    Description = c.Description,
                    Category = new CategoryDto
                    {
                        Id = c.Category.Id,
                        Name = c.Category.Name
                    },
                    Images = c.Images.Select(img => new CarImageDto
                    {
                        Id = img.Id,
                        ImageUrl = img.ImageUrl
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<CarDto?> GetCarByIdAsync(int id)
        {
            return await _context.Cars
                .Include(c => c.Category)
                .Where(c => c.Id == id)
                .Select(c => new CarDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    Description = c.Description,
                    Category = new CategoryDto
                    {
                        Id = c.Category.Id,
                        Name = c.Category.Name
                    }
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CarDto>> GetCarsByCategoryAsync(int categoryId)
        {
            return await _context.Cars
                .Include(c => c.Category)
                .Where(c => c.CategoryId == categoryId)
                .Select(c => new CarDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    Description = c.Description,
                    Category = new CategoryDto
                    {
                        Id = c.Category.Id,
                        Name = c.Category.Name
                    }
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<CarDto>> SearchCarsAsync(string keyword)
        {
            return await _context.Cars
                .Include(c => c.Category)
                .Include(c => c.Images)
                .Where(c => c.Name.Contains(keyword) || c.Description.Contains(keyword))
                .Select(c => new CarDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    Description = c.Description,
                    Category = new CategoryDto
                    {
                        Id = c.Category.Id,
                        Name = c.Category.Name
                    },
                    Images = c.Images.Select(img => new CarImageDto
                    {
                        Id = img.Id,
                        ImageUrl = img.ImageUrl
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task AddCarAsync(Car car)
        {
            await _carRepository.AddAsync(car);
        }

        public async Task UpdateCarAsync(Car car)
        {
            await _carRepository.UpdateAsync(car);
        }

        public async Task DeleteCarAsync(int id)
        {
            await _carRepository.DeleteAsync(id);
        }
    }
}
