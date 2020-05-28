using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Froom.Data.Models.Rooms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly FontysAPI _fontysApi;
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService, FontysAPI fontysApi)
        {
            _roomService = roomService;
            _fontysApi = fontysApi;
        }

        [HttpGet]
        [Route("{campus}/{buildingName}/{floor}")]
        public async Task<IActionResult> GetFloormapRooms(string? campus, string? buildingName, string? floor, DateTime? fromDate,
            DateTime? toDate)
        {
            var rooms = await _roomService.GetRooms(campus, buildingName, floor);
            return Ok(rooms);
        }

        [HttpGet]
        [Route("available/{campus}/{buildingName}/{floor}")]
        public async Task<IActionResult> GetRooms(string campus, string buildingName, string floor, DateTime fromDate,
            DateTime toDate)
        {
            var rooms = await _roomService.GetAvailableRooms(campus, buildingName, floor, fromDate, toDate);
            return Ok(rooms);
        }

        // TODO: Authorize as admin
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PostRooms(IEnumerable<PostRoomModel> model)
        {
            await _roomService.AddRangeAsync(model);
            return Ok();
        }

        // TODO: Authorize as admin
        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutRooms(IEnumerable<PostRoomModel> model)
        {
            await _roomService.UpdateRangeAsync(model);
            return Ok();
        }

        // TODO: Authorize as admin
        [HttpDelete]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteRooms(IEnumerable<DeleteRoomModel> model)
        {
            await _roomService.RemoveRangeAsync(model);
            return Ok();
        }
    }
}