namespace CarStoreAPI.Models.DTO
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;

        public CategoryDto? Category { get; set; } 
        public List<CarImageDto> Images { get; set; } = new List<CarImageDto>();
    }
}
