using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Froom.Data.Database;
using Froom.Data.Dtos.Rooms;
using Froom.Data.Entities;
using Froom.Data.Models;
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

        // TODO: Post DTOs, not whole DB entity
        [HttpPost]
        public async Task<IActionResult> PostRooms([FromBody] RoomModel[] rooms)
        {
            // TODO: Maybe there's a smarter way with AutoMapper
            var entities = rooms.Select(room => new Room() {Points = room.Points, Shape = room.Shape}).ToArray();
            
            await _context.Rooms.AddRangeAsync(entities);
            await _context.SaveChangesAsync();

            return Ok();
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