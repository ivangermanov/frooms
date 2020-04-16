using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Froom.Data.Models.Rooms;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // TODO: Remove, only for testing
        [HttpGet]
        [Authorize(Roles = "student")]
        [Route("user")]
        public async Task<IActionResult> GetUser()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var client = new HttpClient();
            var result = await client.GetStringAsync("https://api.fhict.nl/location/mapimage/EHV/R1/2e");
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetRooms(string? campus, string? buildingName, int? floor)
        {
            var rooms = await _roomService.GetRooms(campus, buildingName, floor);
            return Ok(rooms);
        }

        [HttpGet]
        [Route("available/{campus}/{buildingName}/{floor}")]
        public async Task<IActionResult> GetRooms(string campus, string buildingName, int floor, DateTime fromDate,
            DateTime toDate)
        {
            var rooms = await _roomService.GetAvailableRooms(campus, buildingName, floor, fromDate, toDate);
            return Ok(rooms);
        }

        [HttpPost]
        public async Task<IActionResult> PostRooms(IEnumerable<PostRoomModel> model)
        {
            await _roomService.AddRangeAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutRooms(IEnumerable<PostRoomModel> model)
        {
            await _roomService.UpdateRangeAsync(model);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRooms(IEnumerable<DeleteRoomModel> model)
        {
            await _roomService.RemoveRangeAsync(model);
            return Ok();
        }
    }
}