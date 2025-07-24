using CarStoreAPI.Models.Entities;

namespace CarStoreAPI.Repositories.Interface
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<IEnumerable<Review>> GetReviewsByCarAsync(int carId);
    }
}
