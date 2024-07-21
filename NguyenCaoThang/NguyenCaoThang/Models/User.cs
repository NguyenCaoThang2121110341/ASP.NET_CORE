namespace NguyenCaoThang.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }


        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
}
