using NguyenCaoThang.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenCaoThang.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }

        public double price { get; set; }
        public double price_sale { get; set; }

        public int quantity { get; set; }

        //khoa ngoai category
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } // Thêm từ khóa 'virtual' vào đây

        public string? CategoryName { get; set; }
        public string? Description { get; set; }

        public string? Slug { get; set; }

        public DateTime? created_at { get; set; } = DateTime.Now;
        public DateTime? updated_at { get; set; }

        public string? ImageUrl { get; set; }






    }
}
