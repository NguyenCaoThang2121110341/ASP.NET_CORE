using NguyenCaoThang.Context;
using NguyenCaoThang.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using NguyenCaoThang.Models;
using Microsoft.AspNetCore.Http.HttpResults;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [EnableCors("AllowReactApp")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _dbContext;

        public ProductController(ProductContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Product> products = _dbContext.Set<Product>().ToList();

            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = _dbContext.Set<Product>().FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        [HttpGet("ByCategory/{categoryId}")]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            try
            {
                List<Product> products = _dbContext.Set<Product>()
                    .Where(p => p.CategoryId == categoryId)
                    .ToList();

                return Ok(products);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                return StatusCode(500, "Error retrieving products: " + ex.Message);
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                _dbContext.Set<Product>().Add(product);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {

            }


            return Content("Created product successfully");
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        [HttpGet("search")]
        public IActionResult Search(string keyword)
        {
            var products = _dbContext.Set<Product>()
                                     .Where(p => p.Name.Contains(keyword))
                                     .ToList();
            return Ok(products);
        }
    }
}