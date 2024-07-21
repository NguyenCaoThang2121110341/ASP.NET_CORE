using Microsoft.AspNetCore.Mvc;
using NguyenCaoThang.Context;
using NguyenCaoThang.Models;
using NguyenCaoThang.Context;
using NguyenCaoThang.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NguyenCaoThang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _dbContext;
        // GET: api/<UserController>
        public UserController(UserContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<User> users = _dbContext.Set<User>().ToList();

            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            try
            {
                // Kiểm tra xem người dùng đã tồn tại hay chưa
                bool userExists = _dbContext.Set<User>().Any(u => u.UserName == user.UserName);
                if (userExists)
                {
                    return BadRequest("User with the provided email already exists.");
                }

                // Ghi người dùng mới vào cơ sở dữ liệu
                _dbContext.Set<User>().Add(user);
                _dbContext.SaveChanges();

                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                return StatusCode(500, "Error registering user: " + ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            try
            {
                // Kiểm tra xem người dùng tồn tại và có khớp với thông tin đăng nhập không
                User existingUser = _dbContext.Set<User>().SingleOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
                if (existingUser == null)
                {
                    return BadRequest("Invalid username or password.");
                }

                // Xử lý đăng nhập thành công
                // Ví dụ: Tạo phiên làm việc, lưu thông tin đăng nhập vào cookies hoặc trả về token JWT
                var usern = new { UserName = "John Doe" };
                return Ok(usern);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                return StatusCode(500, "Error during login: " + ex.Message);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
