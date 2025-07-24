using CarStoreAPI.Models.Contracts;

namespace CarStoreAPI.Models.Entities
{
    public class CarImage : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImageUrl { get; set; } = null!;

        public Car Car { get; set; } = null!;
    }
}
