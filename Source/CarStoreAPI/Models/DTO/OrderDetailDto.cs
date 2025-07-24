namespace CarStoreAPI.Models.DTO
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public string? CarName { get; set; }  // Lấy tên xe từ Car
    }
}
