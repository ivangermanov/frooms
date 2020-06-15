using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Froom.Data.Models.Reservations;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;
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

        [HttpGet]
        [Route("rules")]
        public IActionResult GetReservationRules()
        {
            var rules = _reservationService.GetReservationRules();
            return Ok(rules);
        }

        [HttpPost]
        public async Task<IActionResult> PostReservation(PostReservationModel model)
        {
            if (!ReservationRules.IsValid(model.StartDate, model.EndDate)) return BadRequest();

            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var user = await _userService.GetUserByIdAsync(userId);
            if (user.IsBlocked)
                return Forbid("Your profile is blocked and the reservation cannot be made." +
                              " Please contact the system's admin.");

            model.UserId = userId;

            await _reservationService.AddReservationAsync(model);
            return Ok();
        }
    }
}