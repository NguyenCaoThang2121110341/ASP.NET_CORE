using Microsoft.AspNetCore.Mvc;
using NguyenCaoThang.Context;
using NguyenCaoThang.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NguyenCaoThang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryContext _dbContext;
        // GET: api/<CategoryController>

        public CategoryController(CategoryContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Category> categories = _dbContext.Set<Category>().ToList();

            return Ok(categories);
        }
        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            Category category = _dbContext.Set<Category>().Find(id);

            if (category == null)
            {
                return NotFound(); // Trả về mã lỗi 404 Not Found nếu không tìm thấy danh mục
            }

            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
