using System.ComponentModel.DataAnnotations;

namespace MovieReview.Core.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();

    }
}
