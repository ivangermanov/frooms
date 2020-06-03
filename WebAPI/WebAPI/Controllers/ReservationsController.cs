﻿using Froom.Data.Models.Reservations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        IReservationService _reservationService;
        IUserService _userService;

        public ReservationsController(IReservationService reservationService, IUserService userService)
        {
            _reservationService = reservationService;
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        [Route("getCurrentUserReservations")]
        public async Task<IActionResult> GetAllReservationsPerCurrentUser()
        {
            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var exists = await _userService.GetUserAsync(userId);
            if (exists.Any() == false)
            {
                return Ok(null);
            }
            var reservations = await _reservationService.GetReservationsForUser(userId);
            return Ok(reservations);
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
            var user = await _userService.GetUserAsync(model.UserId);

            if (user.Single(x => x.Id == model.UserId).IsBlocked)
            {
                return Forbid("Your profile is blocked and the reservation cannot be made." +
                    " Please contact the system's admin.");
            }

            await _reservationService.AddReservationAsync(model);
            return Ok();
        }
    }
}