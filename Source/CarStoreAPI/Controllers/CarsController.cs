using CarStoreAPI.Models.Entities;
using CarStoreAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CarStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carService.GetAllCarsAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null) return NotFound();
            return Ok(car);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetCarsByCategory(int categoryId)
        {
            var cars = await _carService.GetCarsByCategoryAsync(categoryId);
            return Ok(cars);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCars([FromQuery] string keyword)
        {
            var cars = await _carService.SearchCarsAsync(keyword);
            return Ok(cars);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(Car car)
        {
            await _carService.AddCarAsync(car);
            return Ok(car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, Car car)
        {
            if (id != car.Id) return BadRequest();
            await _carService.UpdateCarAsync(car);
            return Ok(car);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carService.DeleteCarAsync(id);
            return NoContent();
        }
    }
}
