using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Froom.Data.Models.Reservations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers.admin
{
    [Route("api/admin/rooms")]
    [ApiController]
 
    [Authorize(Roles = "admin")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _reservationService;
        public RoomController(IRoomService roomService)
        {
            this._reservationService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> AdminGetAllRoomsPerBuilding()
        {
            var result = await _reservationService.GetAllRooms();
            return Ok(result);
        }

    }
}