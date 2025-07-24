using CarStoreAPI.Models.Entities;

namespace CarStoreAPI.Repositories.Interface
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<IEnumerable<Car>> GetCarsByCategoryAsync(int categoryId);
        Task<IEnumerable<Car>> SearchCarsAsync(string keyword);
    }
}
