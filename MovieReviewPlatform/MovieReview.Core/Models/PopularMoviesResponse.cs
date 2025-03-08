using Newtonsoft.Json;

namespace MovieReview.API.Models
{
    public class PopularMoviesResponse
    {
        public int Page { get; set; }
        public List<Movie> Results { get; set; }
    }

    public class Movie
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }
    }
}
