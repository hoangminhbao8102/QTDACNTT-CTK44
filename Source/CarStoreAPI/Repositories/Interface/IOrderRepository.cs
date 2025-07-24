using CarStoreAPI.Models.Entities;

namespace CarStoreAPI.Repositories.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserAsync(int userId);
    }
}
