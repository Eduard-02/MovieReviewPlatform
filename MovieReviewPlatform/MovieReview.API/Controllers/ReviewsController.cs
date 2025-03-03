using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieReview.API.Data;
using MovieReview.Core.Models;

namespace MovieReview.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReviewsController(AppDbContext context)
        {
            _context = context;
        }

        //Get  /api/reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        //Get  /api/reviews/4
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null) return NotFound();
            return review;
        }

        //Post  /api/reviews
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review);
        }

        //Put  api/reviews/4
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReview(int id, Review updateReview)
        {
            if (id != updateReview.Id) return BadRequest("Review ID mismatch");

            var review = await _context.Reviews.FindAsync(id);

            if (review == null) return NotFound();

            review.Rating = updateReview.Rating;
            review.Comment = updateReview.Comment;
            review.MovieId = updateReview.MovieId;
            review.UserId = updateReview.UserId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Delete  /api/reviews/4
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null) return NotFound();

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
