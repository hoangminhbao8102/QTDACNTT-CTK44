using CarStoreAPI.Models.DTO;
using CarStoreAPI.Models.Entities;

namespace CarStoreAPI.Services.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto?> GetOrderByIdAsync(int id);
        Task<IEnumerable<Order>> GetOrdersByUserAsync(int userId);
        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int id);
    }
}
