using CarStoreAPI.Data.Contexts;
using CarStoreAPI.Models.DTO;
using CarStoreAPI.Models.Entities;
using CarStoreAPI.Repositories.Interface;
using CarStoreAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarStoreAPI.Services.Class
{
    public class OrderService : IOrderService
    {

        private readonly AppDbContext _context;
        private readonly IOrderRepository _repository;
        public OrderService(IOrderRepository repository, AppDbContext context)
        { 
            _repository = repository; 
            _context = context;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Car)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate,
                    Status = o.Status,
                    User = new UserDto
                    {
                        Id = o.User.Id,
                        FullName = o.User.FullName,
                        Email = o.User.Email,
                        Username = o.User.Username,
                        Role = o.User.Role,
                        CreatedAt = o.User.CreatedAt
                    },
                    OrderDetails = o.OrderDetails.Select(od => new OrderDetailDto
                    {
                        Id = od.Id,
                        CarId = od.CarId,
                        Quantity = od.Quantity,
                        Price = od.UnitPrice,
                        CarName = od.Car.Name
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Car)
                .Where(o => o.Id == id)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate,
                    Status = o.Status,
                    User = new UserDto
                    {
                        Id = o.User.Id,
                        FullName = o.User.FullName,
                        Email = o.User.Email,
                        Username = o.User.Username,
                        Role = o.User.Role,
                        CreatedAt = o.User.CreatedAt
                    },
                    OrderDetails = o.OrderDetails.Select(od => new OrderDetailDto
                    {
                        Id = od.Id,
                        CarId = od.CarId,
                        Quantity = od.Quantity,
                        Price = od.UnitPrice,
                        CarName = od.Car.Name
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserAsync(int userId) => await _repository.GetOrdersByUserAsync(userId);

        public async Task AddOrderAsync(Order order) => await _repository.AddAsync(order);

        public async Task UpdateOrderAsync(Order order) => await _repository.UpdateAsync(order);

        public async Task DeleteOrderAsync(int id) => await _repository.DeleteAsync(id);
    }
}
