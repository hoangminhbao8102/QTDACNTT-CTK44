using CarStoreAPI.Data.Contexts;
using CarStoreAPI.Models.DTO;
using CarStoreAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Email và Password là bắt buộc" });
            }

            // Kiểm tra user
            var user = _context.Users.FirstOrDefault(u =>
                u.Email == request.Email && u.Password == request.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Sai email hoặc mật khẩu" });
            }

            var response = new LoginResponse
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Username = user.Username,
                Role = user.Role,
                Message = "Đăng nhập thành công"
            };

            return Ok(response);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.Username))
            {
                return BadRequest(new { message = "Email, Username và Password là bắt buộc" });
            }

            // Kiểm tra email hoặc username đã tồn tại
            if (_context.Users.Any(u => u.Email == request.Email || u.Username == request.Username))
            {
                return Conflict(new { message = "Email hoặc Username đã tồn tại" });
            }

            var newUser = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                Username = request.Username,
                Password = request.Password,      // Plain text để test
                PasswordHash = "",                // Chưa dùng hash
                Role = request.Role,              // Mặc định "User", Admin tự seed
                CreatedAt = DateTime.Now
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return Ok(new { message = "Đăng ký thành công", userId = newUser.Id });
        }

    }
}
