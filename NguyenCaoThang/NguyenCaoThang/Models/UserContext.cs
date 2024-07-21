using NguyenCaoThang.Models;
using Microsoft.EntityFrameworkCore;

namespace NguyenCaoThang.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        DbSet<User> Users
        {
            get;
            set;
        }
    }
}