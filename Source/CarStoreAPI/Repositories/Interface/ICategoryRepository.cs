using CarStoreAPI.Models.Entities;

namespace CarStoreAPI.Repositories.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category?> GetByNameAsync(string name);
    }
}
