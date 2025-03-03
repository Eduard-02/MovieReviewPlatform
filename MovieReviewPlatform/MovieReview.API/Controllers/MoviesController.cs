using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieReview.API.Data;
using MovieReview.Core.Models;

namespace MovieReview.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        //Get  api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        //Get  api/movies/4
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return NotFound();
            return movie;
        }

        //Post  api/movies
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        //Put  api/movies/4
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMovie(int id, Movie updateMovie)
        {
            if (id != updateMovie.Id) return BadRequest("Movie ID mismatch");

            var movie = await _context.Movies.Include(m => m.MovieGenres).FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null) return NotFound();

            movie.Title = updateMovie.Title;
            movie.Description = updateMovie.Description;
            movie.ReleaseDate = updateMovie.ReleaseDate;

            movie.MovieGenres.Clear();
            foreach (var genre in updateMovie.MovieGenres)
            {
                movie.MovieGenres.Add(new MovieGenre { MovieId = movie.Id, GenreId = genre.GenreId });
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Delete  api/movies/4
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return NotFound();

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}