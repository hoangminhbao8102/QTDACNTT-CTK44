using CarStoreAPI.Models.Contracts;

namespace CarStoreAPI.Models.Entities
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public int CategoryId { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }

        public Category Category { get; set; } = null!;
        public ICollection<CarImage> Images { get; set; } = new List<CarImage>();
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
