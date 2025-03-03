using System.ComponentModel.DataAnnotations;

namespace MovieReview.Core.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Role { get; set; }

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
