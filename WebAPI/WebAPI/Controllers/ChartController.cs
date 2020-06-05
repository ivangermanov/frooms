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

namespace WebAPI.Controllers
{
    [Route("api/charts")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly IChartService _chartService;

        public ChartController(IChartService chartService)
        {
            _chartService = chartService;
        }

        [HttpGet]
        [Route("reservations/building")]
        public async Task<IActionResult> GetBuildingReservationsChartData(int? items = null, DateTime? start = null, DateTime? end = null)
        {
            var data = await _chartService.GetBuildingReservationsChartData(items, start, end);

            return Ok(data);
        }

        [HttpGet]
        [Route("reservations/day")]
        public async Task<IActionResult> GetDayReservationsChartData(DateTime? start = null, DateTime? end = null)
        {
            var data = await _chartService.GetDayReservationsChartData(start, end);
            return Ok(data);
        }

        [HttpGet]
        [Route("reservations/peak-hours")]
        public async Task<IActionResult> GetPeakHoursReservationsChartData(DateTime? start = null, DateTime? end = null)
        {
            var data = await _chartService.GetPeakHoursReservationsChartData(start, end);
            return Ok(data);
        }
    }
}