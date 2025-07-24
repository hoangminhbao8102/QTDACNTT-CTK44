namespace CarStoreAPI.Models.DTO
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;

        public UserDto? User { get; set; } 
        public CarDto? Car { get; set; }
    }
}
