using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieReview.API.Data;
using MovieReview.Core.Models;

namespace MovieReview.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        //Get  /api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        //Get  /api/users/4
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();
            return user;
        }

        //Post  /api/users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id}, user);
        }

        //Put  api/users/4
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, User updateUser)
        {
            if (id != updateUser.Id) return BadRequest("User ID mismatch");

            var user = await _context.Users.FindAsync(id);

            if (user == null) return NotFound();

            user.Name = updateUser.Name;
            user.Email = updateUser.Email;
            user.Role = updateUser.Role;
            user.Reviews = updateUser.Reviews;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Delete  /api/users/4
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
