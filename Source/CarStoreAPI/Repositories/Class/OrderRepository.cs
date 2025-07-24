using CarStoreAPI.Data.Contexts;
using CarStoreAPI.Models.Entities;
using CarStoreAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarStoreAPI.Repositories.Class
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Order>> GetAllAsync() =>
            await _context.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Car).ToListAsync();

        public async Task<Order?> GetByIdAsync(int id) =>
            await _context.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Car)
                                 .FirstOrDefaultAsync(o => o.Id == id);

        public async Task<IEnumerable<Order>> GetOrdersByUserAsync(int userId) =>
            await _context.Orders.Where(o => o.UserId == userId)
                                 .Include(o => o.OrderDetails)
                                 .ThenInclude(od => od.Car)
                                 .ToListAsync();

        public async Task AddAsync(Order order) { _context.Orders.Add(order); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Order order) { _context.Orders.Update(order); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Orders.FindAsync(id);
            if (entity != null) { _context.Orders.Remove(entity); await _context.SaveChangesAsync(); }
        }
    }
}
