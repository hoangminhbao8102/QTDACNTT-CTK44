using CarStoreAPI.Models.Contracts;

namespace CarStoreAPI.Models.Entities
{
    public class OrderDetail : IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CarId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public Order Order { get; set; } = null!;
        public Car Car { get; set; } = null!;
    }
}
