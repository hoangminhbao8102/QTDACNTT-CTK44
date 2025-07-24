using CarStoreAPI.Data.Contexts;
using CarStoreAPI.Models.Entities;

namespace CarStoreAPI.Data.Seeders
{
    public class DataSeeder : IDataSeeder
    {
        private readonly AppDbContext _dbContext;

        public DataSeeder(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Cars.Any())
            {
                return; // Nếu đã có dữ liệu thì bỏ qua
            }

            var users = AddUsers();
            var categories = AddCategories();
            var cars = AddCars(categories);
            AddCarImages(cars);
            AddOrders(users, cars);
            AddReviews(users, cars);
        }

        // ----------------- USERS -----------------
        private IList<User> AddUsers()
        {
            var users = new List<User>()
            {
                new() { FullName = "Admin", Email = "admin@carstore.com", Username = "admin", Password = "123456", PasswordHash = "hash1", Role = "Admin", CreatedAt = DateTime.Now },
                new() { FullName = "Nguyen Van A", Email = "a@carstore.com", Username = "nguyenvana", Password = "123456", PasswordHash = "hash2", Role = "Customer", CreatedAt = DateTime.Now },
                new() { FullName = "Tran Thi B", Email = "b@carstore.com", Username = "tranthib", Password = "123456", PasswordHash = "hash3", Role = "Customer", CreatedAt = DateTime.Now },
                new() { FullName = "Le Van C", Email = "c@carstore.com", Username = "levanc", Password = "123456", PasswordHash = "hash_c", Role = "Customer", CreatedAt = DateTime.Now },
                new() { FullName = "Pham Thi D", Email = "d@carstore.com", Username = "phamthid", Password = "123456", PasswordHash = "hash_d", Role = "Customer", CreatedAt = DateTime.Now }
            };

            _dbContext.AddRange(users);
            _dbContext.SaveChanges();
            return users;
        }

        // ----------------- CATEGORIES -----------------
        private IList<Category> AddCategories()
        {
            var categories = new List<Category>()
            {
                new() { Name = "Sedan" },
                new() { Name = "SUV" },
                new() { Name = "Pickup" },
                new() { Name = "Sports Car" }
            };

            _dbContext.AddRange(categories);
            _dbContext.SaveChanges();
            return categories;
        }

        // ----------------- CARS -----------------
        private IList<Car> AddCars(IList<Category> categories)
        {
            var cars = new List<Car>()
            {
                new() { Name = "Toyota Camry", Price = 35000, Description = "Sedan hạng D, tiết kiệm nhiên liệu", CategoryId = categories[0].Id, Stock = 10, CreatedAt = DateTime.Now },
                new() { Name = "Honda Accord", Price = 37000, Description = "Sedan cao cấp, tiện nghi", CategoryId = categories[0].Id, Stock = 8, CreatedAt = DateTime.Now },
                new() { Name = "Mazda 6", Price = 33000, Description = "Sedan thiết kế đẹp, vận hành ổn định", CategoryId = categories[0].Id, Stock = 7, CreatedAt = DateTime.Now },
                new() { Name = "Kia K5", Price = 31000, Description = "Sedan giá mềm, option nhiều", CategoryId = categories[0].Id, Stock = 6, CreatedAt = DateTime.Now },
                new() { Name = "Hyundai Sonata", Price = 32000, Description = "Sedan êm ái, tiết kiệm nhiên liệu", CategoryId = categories[0].Id, Stock = 5, CreatedAt = DateTime.Now },

                new() { Name = "Honda CR-V", Price = 45000, Description = "SUV gia đình rộng rãi", CategoryId = categories[1].Id, Stock = 9, CreatedAt = DateTime.Now },
                new() { Name = "Toyota RAV4", Price = 46000, Description = "SUV bán chạy, an toàn cao", CategoryId = categories[1].Id, Stock = 10, CreatedAt = DateTime.Now },
                new() { Name = "Mazda CX-5", Price = 42000, Description = "SUV tầm trung, thiết kế đẹp", CategoryId = categories[1].Id, Stock = 6, CreatedAt = DateTime.Now },
                new() { Name = "Hyundai SantaFe", Price = 48000, Description = "SUV 7 chỗ cao cấp", CategoryId = categories[1].Id, Stock = 5, CreatedAt = DateTime.Now },
                new() { Name = "Kia Sorento", Price = 47000, Description = "SUV 7 chỗ, giá tốt", CategoryId = categories[1].Id, Stock = 4, CreatedAt = DateTime.Now },

                new() { Name = "Ford Ranger", Price = 55000, Description = "Pickup mạnh mẽ, đa dụng", CategoryId = categories[2].Id, Stock = 8, CreatedAt = DateTime.Now },
                new() { Name = "Toyota Hilux", Price = 53000, Description = "Pickup bền bỉ, off-road tốt", CategoryId = categories[2].Id, Stock = 7, CreatedAt = DateTime.Now },
                new() { Name = "Isuzu D-Max", Price = 52000, Description = "Pickup tiết kiệm nhiên liệu", CategoryId = categories[2].Id, Stock = 6, CreatedAt = DateTime.Now },
                new() { Name = "Chevrolet Colorado", Price = 54000, Description = "Pickup Mỹ mạnh mẽ", CategoryId = categories[2].Id, Stock = 5, CreatedAt = DateTime.Now },
                new() { Name = "Mitsubishi Triton", Price = 51000, Description = "Pickup giá tốt, thiết kế đẹp", CategoryId = categories[2].Id, Stock = 6, CreatedAt = DateTime.Now },

                new() { Name = "Porsche 911", Price = 120000, Description = "Sports Car hiệu suất cao", CategoryId = categories[3].Id, Stock = 2, CreatedAt = DateTime.Now },
                new() { Name = "Ferrari F8", Price = 300000, Description = "Sports Car đỉnh cao tốc độ", CategoryId = categories[3].Id, Stock = 1, CreatedAt = DateTime.Now },
                new() { Name = "Lamborghini Huracan", Price = 250000, Description = "Siêu xe phong cách Ý", CategoryId = categories[3].Id, Stock = 1, CreatedAt = DateTime.Now },
                new() { Name = "Chevrolet Corvette", Price = 90000, Description = "Sports Car Mỹ giá tốt", CategoryId = categories[3].Id, Stock = 2, CreatedAt = DateTime.Now },
                new() { Name = "Nissan GT-R", Price = 100000, Description = "Sports Car Nhật huyền thoại", CategoryId = categories[3].Id, Stock = 2, CreatedAt = DateTime.Now }
            };

            _dbContext.AddRange(cars);
            _dbContext.SaveChanges();
            return cars;
        }

        // ----------------- CAR IMAGES -----------------
        private void AddCarImages(IList<Car> cars)
        {
            var images = new List<CarImage>();

            foreach (var car in cars)
            {
                images.Add(new CarImage { CarId = car.Id, ImageUrl = $"/images/cars/{car.Name.Replace(" ", "-").ToLower()}.jpg" });
            }

            _dbContext.AddRange(images);
            _dbContext.SaveChanges();
        }

        // ----------------- ORDERS -----------------
        private void AddOrders(IList<User> users, IList<Car> cars)
        {
            var orders = new List<Order>()
            {
                // Order 1
                new()
                {
                    UserId = users[1].Id,
                    OrderDate = DateTime.Now.AddDays(-10),
                    Status = "Completed",
                    OrderDetails = new List<OrderDetail>()
                    {
                        new() { CarId = cars[0].Id, Quantity = 1, UnitPrice = cars[0].Price },
                        new() { CarId = cars[6].Id, Quantity = 1, UnitPrice = cars[6].Price }
                    }
                },
                // Order 2
                new()
                {
                    UserId = users[2].Id,
                    OrderDate = DateTime.Now.AddDays(-8),
                    Status = "Pending",
                    OrderDetails = new List<OrderDetail>()
                    {
                        new() { CarId = cars[10].Id, Quantity = 1, UnitPrice = cars[10].Price }
                    }
                },
                // Order 3
                new()
                {
                    UserId = users[3].Id,
                    OrderDate = DateTime.Now.AddDays(-6),
                    Status = "Completed",
                    OrderDetails = new List<OrderDetail>()
                    {
                        new() { CarId = cars[16].Id, Quantity = 1, UnitPrice = cars[16].Price }
                    }
                },
                // Order 4
                new()
                {
                    UserId = users[4].Id,
                    OrderDate = DateTime.Now.AddDays(-5),
                    Status = "Completed",
                    OrderDetails = new List<OrderDetail>()
                    {
                        new() { CarId = cars[3].Id, Quantity = 1, UnitPrice = cars[3].Price },
                        new() { CarId = cars[12].Id, Quantity = 1, UnitPrice = cars[12].Price }
                    }
                },
                // Order 5
                new()
                {
                    UserId = users[1].Id,
                    OrderDate = DateTime.Now.AddDays(-4),
                    Status = "Pending",
                    OrderDetails = new List<OrderDetail>()
                    {
                        new() { CarId = cars[5].Id, Quantity = 1, UnitPrice = cars[5].Price }
                    }
                },
                // Order 6
                new()
                {
                    UserId = users[2].Id,
                    OrderDate = DateTime.Now.AddDays(-3),
                    Status = "Completed",
                    OrderDetails = new List<OrderDetail>()
                    {
                        new() { CarId = cars[14].Id, Quantity = 2, UnitPrice = cars[14].Price }
                    }
                },
                // Order 7
                new()
                {
                    UserId = users[3].Id,
                    OrderDate = DateTime.Now.AddDays(-2),
                    Status = "Pending",
                    OrderDetails = new List<OrderDetail>()
                    {
                        new() { CarId = cars[8].Id, Quantity = 1, UnitPrice = cars[8].Price }
                    }
                },
                // Order 8
                new()
                {
                    UserId = users[4].Id,
                    OrderDate = DateTime.Now.AddDays(-2),
                    Status = "Completed",
                    OrderDetails = new List<OrderDetail>()
                    {
                        new() { CarId = cars[19].Id, Quantity = 1, UnitPrice = cars[19].Price }
                    }
                },
                // Order 9
                new()
                {
                    UserId = users[1].Id,
                    OrderDate = DateTime.Now.AddDays(-1),
                    Status = "Completed",
                    OrderDetails = new List<OrderDetail>()
                    {
                        new() { CarId = cars[2].Id, Quantity = 1, UnitPrice = cars[2].Price }
                    }
                },
                // Order 10
                new()
                {
                    UserId = users[2].Id,
                    OrderDate = DateTime.Now,
                    Status = "Pending",
                    OrderDetails = new List<OrderDetail>()
                    {
                        new() { CarId = cars[4].Id, Quantity = 1, UnitPrice = cars[4].Price }
                    }
                }
            };

            _dbContext.AddRange(orders);
            _dbContext.SaveChanges();
        }

        // ----------------- REVIEWS -----------------
        private void AddReviews(IList<User> users, IList<Car> cars)
        {
            var reviews = new List<Review>()
            {
                new() { CarId = cars[0].Id, UserId = users[1].Id, Rating = 5, Comment = "Sedan êm ái, phù hợp cho gia đình!", CreatedAt = DateTime.Now },
                new() { CarId = cars[6].Id, UserId = users[2].Id, Rating = 4, Comment = "SUV rộng rãi, option đầy đủ!", CreatedAt = DateTime.Now },
                new() { CarId = cars[16].Id, UserId = users[3].Id, Rating = 5, Comment = "Siêu xe tốc độ đỉnh cao!", CreatedAt = DateTime.Now },
                new() { CarId = cars[10].Id, UserId = users[4].Id, Rating = 3, Comment = "Pickup mạnh mẽ nhưng khá ồn.", CreatedAt = DateTime.Now },
                new() { CarId = cars[3].Id, UserId = users[1].Id, Rating = 4, Comment = "Sedan giá tốt, thiết kế đẹp!", CreatedAt = DateTime.Now },
                new() { CarId = cars[8].Id, UserId = users[2].Id, Rating = 5, Comment = "SUV 7 chỗ hoàn hảo cho du lịch!", CreatedAt = DateTime.Now },
                new() { CarId = cars[14].Id, UserId = users[3].Id, Rating = 4, Comment = "Pickup thiết kế đẹp, tiết kiệm nhiên liệu.", CreatedAt = DateTime.Now },
                new() { CarId = cars[19].Id, UserId = users[4].Id, Rating = 5, Comment = "Nissan GT-R cực mạnh, cảm giác lái tuyệt vời!", CreatedAt = DateTime.Now },
                new() { CarId = cars[2].Id, UserId = users[1].Id, Rating = 3, Comment = "Mazda 6 chạy ổn nhưng hơi rung.", CreatedAt = DateTime.Now },
                new() { CarId = cars[4].Id, UserId = users[2].Id, Rating = 4, Comment = "Sonata tiết kiệm nhiên liệu, giá hợp lý.", CreatedAt = DateTime.Now }
            };

            _dbContext.AddRange(reviews);
            _dbContext.SaveChanges();
        }
    }
}
