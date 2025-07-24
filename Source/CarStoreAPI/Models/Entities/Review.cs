using CarStoreAPI.Models.Contracts;

namespace CarStoreAPI.Models.Entities
{
    public class Review : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; } // 1-5
        public string Comment { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public Car Car { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
