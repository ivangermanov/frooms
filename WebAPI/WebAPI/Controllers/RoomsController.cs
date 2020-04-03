using Froom.Data.Models.Rooms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }


        [HttpGet]
        public async Task<IActionResult> GetRooms(string? campus, string? buildingName, int? floor)
        {
            var rooms = await _roomService.GetRooms(campus, buildingName, floor);
            return Ok(rooms);
        }

        [HttpGet]
        [Route("available/{campus}/{buildingName}/{floor}")]
        public async Task<IActionResult> GetRooms(string campus, string buildingName, int floor, DateTime fromDate, DateTime toDate)
        {
            var rooms = await _roomService.GetRooms(campus, buildingName, floor, fromDate, toDate);
            return Ok(rooms);
        }

        [HttpPost]
        public async Task<IActionResult> PostRooms(IEnumerable<PostRoomModel> model)
        {
            await _roomService.AddRangeAsync(model);
            return Ok();
        }

        [HttpPost]
        [Route("addRange")]
        public async Task<IActionResult> AddRange(PostRoomModel[] models)
        {
            await _roomService.AddRangeAsync(models);

            return Ok();
        }
    }
}