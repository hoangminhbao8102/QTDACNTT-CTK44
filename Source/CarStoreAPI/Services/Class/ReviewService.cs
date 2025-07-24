using CarStoreAPI.Data.Contexts;
using CarStoreAPI.Models.DTO;
using CarStoreAPI.Models.Entities;
using CarStoreAPI.Repositories.Interface;
using CarStoreAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarStoreAPI.Services.Class
{
    public class ReviewService : IReviewService
    {
        private readonly AppDbContext _context;
        private readonly IReviewRepository _repository;
        public ReviewService(IReviewRepository repository, AppDbContext context)
        { 
            _repository = repository; 
            _context = context;
        }

        public async Task<IEnumerable<ReviewDto>> GetAllReviewsAsync()
        {
            return await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Car)
                    .ThenInclude(c => c.Category)
                .Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    User = new UserDto
                    {
                        Id = r.User.Id,
                        FullName = r.User.FullName,
                        Email = r.User.Email,
                        Username = r.User.Username,
                        Role = r.User.Role,
                        CreatedAt = r.User.CreatedAt
                    },
                    Car = new CarDto
                    {
                        Id = r.Car.Id,
                        Name = r.Car.Name,
                        Price = r.Car.Price,
                        Description = r.Car.Description,
                        Category = new CategoryDto
                        {
                            Id = r.Car.Category.Id,
                            Name = r.Car.Category.Name
                        }
                    }
                })
                .ToListAsync();
        }

        public async Task<ReviewDto?> GetReviewByIdAsync(int id)
        {
            return await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Car)
                    .ThenInclude(c => c.Category)
                .Where(r => r.Id == id)
                .Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    User = new UserDto
                    {
                        Id = r.User.Id,
                        FullName = r.User.FullName,
                        Email = r.User.Email,
                        Username = r.User.Username,
                        Role = r.User.Role,
                        CreatedAt = r.User.CreatedAt
                    },
                    Car = new CarDto
                    {
                        Id = r.Car.Id,
                        Name = r.Car.Name,
                        Price = r.Car.Price,
                        Description = r.Car.Description,
                        Category = new CategoryDto
                        {
                            Id = r.Car.Category.Id,
                            Name = r.Car.Category.Name
                        }
                    }
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByCarIdAsync(int carId)
        {
            return await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Car)
                    .ThenInclude(c => c.Category)
                .Where(r => r.CarId == carId)
                .Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    User = new UserDto
                    {
                        Id = r.User.Id,
                        FullName = r.User.FullName,
                        Email = r.User.Email,
                        Username = r.User.Username,
                        Role = r.User.Role,
                        CreatedAt = r.User.CreatedAt
                    },
                    Car = new CarDto
                    {
                        Id = r.Car.Id,
                        Name = r.Car.Name,
                        Price = r.Car.Price,
                        Description = r.Car.Description,
                        Category = new CategoryDto
                        {
                            Id = r.Car.Category.Id,
                            Name = r.Car.Category.Name
                        }
                    }
                })
                .ToListAsync();
        }
        public async Task AddReviewAsync(Review review) => await _repository.AddAsync(review);

        public async Task UpdateReviewAsync(Review review) => await _repository.UpdateAsync(review);

        public async Task DeleteReviewAsync(int id) => await _repository.DeleteAsync(id);
    }
}
