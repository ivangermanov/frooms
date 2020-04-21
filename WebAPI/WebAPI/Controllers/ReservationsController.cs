using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetReservationsForUser(Guid userId)
        {
            return Ok(_reservationService.GetReservationsForUser(userId));
        }

        [HttpGet]
        [Route("{roomId}")]
        public IActionResult GetReservationsForRoom(int roomId)
        {
            return Ok(_reservationService.GetReservationsForRoom(roomId));
        }
    }
}