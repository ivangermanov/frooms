﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}