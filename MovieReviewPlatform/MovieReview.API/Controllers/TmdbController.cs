using Microsoft.AspNetCore.Mvc;
using MovieReview.API.Models;
using MovieReview.API.Services;
using System.Threading.Tasks;

namespace MovieReview.API.Controllers
{
    [ApiController]
    [Route("api/tmdb")]
    public class TmdbController : ControllerBase
    {
        private readonly TmdbService _tmdbService;

        public TmdbController(TmdbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [HttpGet("popular")]
        public async Task<IActionResult> GetPopularMovies()
        {
            var movies = await _tmdbService.GetPopularMoviesAsync();
            return Ok(movies);
        }
    }
}
