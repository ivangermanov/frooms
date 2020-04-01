using Froom.Data.Dtos.Rooms;
using Froom.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RoomDto>), 200)]
        public IActionResult Rooms()
        {
            return Ok(_roomService.Rooms());
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostRoomModel model)
        {
            await _roomService.AddAsync(model);

            return Ok();
        }
    }
}
