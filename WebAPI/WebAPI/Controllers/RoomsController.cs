using Froom.Data.Models.Rooms;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [Route("{campus}/{buildingName}/{floor}")]
        public IActionResult GetRooms(string campus, string buildingName, int? floor)
        {
            return Ok(_roomService.GetRooms(campus, buildingName, floor));
        }

        [HttpGet]
        [Route("available/{campus}/{buildingName}/{floor}")]
        public IActionResult GetAvailableRooms(string campus, string buildingName, int floor, DateTime fromDate, DateTime toDate)
        {
            return Ok(_roomService.GetAvailableRooms(campus, buildingName, floor, fromDate, toDate));
        }

        [HttpPost]
        public async Task<IActionResult> PostRooms(PostRoomModel model)
        {
            await _roomService.AddRoomAsync(model);

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