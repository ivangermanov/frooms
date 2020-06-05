using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Froom.Data.Dtos;
using Froom.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers.admin
{
    [Route("api/admin/charts")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class ChartController : ControllerBase
    {
        private readonly IChartService _chartService;

        public ChartController(IChartService chartService)
        {
            _chartService = chartService;
        }

        [HttpGet]
        [Route("reservations/user")]
        public async Task<IActionResult> GetUserReservationsChartData(int? items = null, DateTime? start = null, DateTime? end = null)
        {
            var data = await _chartService.GetUserReservationsChartData(items, start, end);

            return Ok(data);
        }
    }
}