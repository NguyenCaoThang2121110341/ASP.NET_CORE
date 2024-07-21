using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenCaoThang.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int? parentId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string? Slug { get; set; }
        public string? ImageUrl { get; set; }

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

        public bool? status { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Product> Products { get; set; } // Thêm từ khóa 'virtual' vào đây

    }



}

