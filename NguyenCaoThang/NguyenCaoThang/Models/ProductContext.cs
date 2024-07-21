using NguyenCaoThang.Models;
using Microsoft.EntityFrameworkCore;

namespace NguyenCaoThang.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
        DbSet<Product> Products
        {
            get;
            set;
        }
    }
}