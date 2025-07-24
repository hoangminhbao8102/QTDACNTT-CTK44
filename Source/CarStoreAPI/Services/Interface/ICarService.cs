using CarStoreAPI.Models.DTO;
using CarStoreAPI.Models.Entities;

namespace CarStoreAPI.Services.Interface
{
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetAllCarsAsync();
        Task<CarDto?> GetCarByIdAsync(int id);
        Task<IEnumerable<CarDto>> GetCarsByCategoryAsync(int categoryId);
        Task<IEnumerable<CarDto>> SearchCarsAsync(string keyword);
        Task AddCarAsync(Car car);
        Task UpdateCarAsync(Car car);
        Task DeleteCarAsync(int id);
    }
}
