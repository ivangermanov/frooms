using Froom.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public interface IChartService
    {
        /// <summary>
        /// Get the chart data for a user reservations.
        /// </summary>
        /// <param name="items">The limit for the number of items.</param>
        /// <param name="start">The limit for the start date</param>
        /// <param name="end">The limit for the end date.</param>
        public Task<ChartDataDto> GetUserReservationsChartData(int? items = null, DateTime? start = null, DateTime? end = null);

        /// <summary>
        /// Get the chart data for a building reservations.
        /// </summary>
        /// <param name="items">The limit for the number of items.</param>
        /// <param name="start">The limit for the start date</param>
        /// <param name="end">The limit for the end date.</param>
        public Task<ChartDataDto> GetBuildingReservationsChartData(int? items = null, DateTime? start = null, DateTime? end = null);

        /// <summary>
        /// Get the chart data for week days reservations.
        /// </summary>
        /// <param name="start">The limit for the start date</param>
        /// <param name="end">The limit for the end date.</param>
        public Task<ChartDataDto> GetDayReservationsChartData(DateTime? start = null, DateTime? end = null);

        /// <summary>
        /// Get the chart data for peak hours reservations.
        /// </summary>
        /// <param name="start">The limit for the start date</param>
        /// <param name="end">The limit for the end date.</param>
        public Task<ChartDataDto> GetPeakHoursReservationsChartData(DateTime? start = null, DateTime? end = null);
    }
}
