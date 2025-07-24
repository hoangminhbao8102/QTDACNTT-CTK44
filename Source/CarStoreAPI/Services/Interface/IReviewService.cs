using CarStoreAPI.Models.DTO;
using CarStoreAPI.Models.Entities;

namespace CarStoreAPI.Services.Interface
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetAllReviewsAsync();
        Task<ReviewDto?> GetReviewByIdAsync(int id);
        Task<IEnumerable<ReviewDto>> GetReviewsByCarIdAsync(int carId);
        Task AddReviewAsync(Review review);
        Task UpdateReviewAsync(Review review);
        Task DeleteReviewAsync(int id);
    }
}
