using System.Collections.Generic;
using System.Threading.Tasks;
using Froom.Data.Database;
using Froom.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // TODO: Make one base controller so the context is not set in every controller
        private readonly FroomContext _context;

        public UserController(FroomContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            // TODO: Return DTOs, not whole DB entity
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            // TODO: Return DTOs, not whole DB entity
            var user = await _context.Users.FindAsync(id);

            if (user == null) return NotFound();

            return user;
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        // TODO: Put parameter as DTO, not whole DB entity
        public async Task<IActionResult> PutUser(long id, User user)
        {
            //if (id != user.Id)
            //{
            //    return BadRequest();
            //}

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        // TODO: Put user as DTO, not whole DB entity
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new {id = user.Id}, user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(long id)
        {
            //return _context.Users.Any(e => e.Id == id);
            return true;
        }
    }
}