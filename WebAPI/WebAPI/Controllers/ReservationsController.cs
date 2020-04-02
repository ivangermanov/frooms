using Microsoft.AspNetCore.Mvc;
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
        [Route("{userNumber}")]
        public IActionResult GetReservationsForUser(int userNumber)
        {
            return Ok(_reservationService.GetReservationsForUser(userNumber));
        }

        [HttpGet]
        [Route("{roomId}")]
        public IActionResult GetReservationsForRoom(int roomId)
        {
            return Ok(_reservationService.GetReservationsForRoom(roomId));
        }
    }
}