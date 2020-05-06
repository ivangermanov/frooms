using Froom.Data.Models.Reservations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetReservationsForUser(Guid userId)
        {
            var reservations = await _reservationService.GetReservationsForUser(userId);
            return Ok(reservations);
        }

        [HttpGet]
        [Route("{roomId}")]
        public async Task<IActionResult> GetReservationsForRoom(int roomId)
        {
            var reservations = await _reservationService.GetReservationsForRoom(roomId);
            return Ok(reservations);
        }

        [HttpPost]
        public async Task<IActionResult> PostReservation(PostReservationModel model)
        {
            await _reservationService.AddReservationAsync(model);
            return Ok();
        }
    }
}