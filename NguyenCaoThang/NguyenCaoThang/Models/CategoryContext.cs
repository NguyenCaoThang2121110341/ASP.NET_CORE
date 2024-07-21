using NguyenCaoThang.Models;
using Microsoft.EntityFrameworkCore;

namespace NguyenCaoThang.Context
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options) { }
        DbSet<Category> Category
        {
            get;
            set;
        }
    }
}