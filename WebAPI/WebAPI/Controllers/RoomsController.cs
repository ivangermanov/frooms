using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Froom.Data.Database;
using Froom.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        // TODO: Make one base controller so the context is not set in every controller
        private readonly FroomContext _context;

        public RoomsController(FroomContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            // TODO: Return DTOs, not whole DB entity
            var rooms = await _context.Rooms.ToListAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult PostRoom([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // TODO: Post DTOs, not whole DB entity
        [HttpPost]
        public IActionResult PostRooms([FromBody] List<Room> rooms)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public IActionResult PutRoom(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            throw new NotImplementedException();
        }
    }
}