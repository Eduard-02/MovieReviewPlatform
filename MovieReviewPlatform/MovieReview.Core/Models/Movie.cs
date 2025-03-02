namespace MovieReview.Core.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();

    }
}
