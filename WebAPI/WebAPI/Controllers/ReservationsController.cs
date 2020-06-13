using System;
using System.Threading.Tasks;
using Froom.Data.Models.Reservations;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IUserService _userService;

        public ReservationsController(IReservationService reservationService, IUserService userService)
        {
            _reservationService = reservationService;
            _userService = userService;
        }

        [HttpGet]
        [Route("user/{userId}")]
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
            var user = await _userService.GetUserByIdAsync(model.UserId);

            if (user is null)
                return BadRequest();

            if (user.IsBlocked)
                return Forbid("Your profile is blocked and the reservation cannot be made." +
                              " Please contact the system's admin.");

            await _reservationService.AddReservationAsync(model);
            return Ok();
        }
    }
}