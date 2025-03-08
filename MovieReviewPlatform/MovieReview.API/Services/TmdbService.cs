using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;
using MovieReview.API.Models;

namespace MovieReview.API.Services
{
    public class TmdbService 
    {
        private readonly HttpClient _httpClient;
        private readonly string? _apiKey;

        public TmdbService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["TMDb:ApiKey"];

            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new InvalidOperationException("TMDb API key is missing or invalid.");
            }
        }

        public async Task<PopularMoviesResponse> GetPopularMoviesAsync()
        {
            if (_apiKey == null)
            {
                throw new InvalidOperationException("TMDb API key is not available.");
            }

            var response = await _httpClient.GetAsync($"https://api.themoviedb.org/3/movie/popular?api_key={_apiKey}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PopularMoviesResponse>(content);
        }
    }
}
