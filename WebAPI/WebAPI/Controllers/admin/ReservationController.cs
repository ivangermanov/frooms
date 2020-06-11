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
    [Route("api/admin/reservations")]
    [ApiController]
 
    [Authorize(Roles = "admin")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            this._reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> AdminGetAllReservations()
        {
            var result = await _reservationService.GetAllReservations();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{reservationId}")]
        public async Task<IActionResult> DeleteReservation(int reservationId)
        {
            await _reservationService.DeleteReservation(reservationId);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateReservation(AdminUpdateReservationModel reservationAdmin)
        {
            await _reservationService.UpdateReservation(reservationAdmin);
            return Ok();
        }
    }
}