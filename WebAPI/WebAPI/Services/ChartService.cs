using Froom.Data.Dtos;
using Froom.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class ChartService : IChartService
    {
        private readonly IReservationRepository _reservationRepository;

        public ChartService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<ChartDataDto> GetUserReservationsChartData(int? items = null, DateTime? start = null, DateTime? end = null)
        {
            const string name = "Users";
            const string title = "Top users with most reservations";
            const string chartType = "bar";
            var categories = new List<string>();
            var data = new List<int>();

            var chartData = await _reservationRepository.GetAll()
                .Where(r => !start.HasValue || DateTime.Compare(r.StartDate, Convert.ToDateTime(start)) >= 0)
                .Where(r => !end.HasValue || DateTime.Compare(r.EndDate, Convert.ToDateTime(end)) <= 0)
                .GroupBy(r => r.User.Name)
                .Select(g => new
                {
                    g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(a => a.Count)
                .Take(items.HasValue ? Convert.ToInt32(items) : int.MaxValue)
                .ToListAsync();

            chartData.ForEach(x =>
            {
                categories.Add(x.Key);
                data.Add(x.Count);
            });

            var series = new List<ChartDataSeries>() { new ChartDataSeries() { Name = "Reservations", Data = data } };
            var chartDataDto = new ChartDataDto()
            {
                Name = name,
                Title = title,
                ChartType = chartType,
                Categories = categories,
                Series = series
            };

            return chartDataDto;
        }

        public async Task<ChartDataDto> GetBuildingReservationsChartData(int? items = null, DateTime? start = null, DateTime? end = null)
        {
            const string name = "Buildings";
            const string title = "Top buildings with most reservations";
            const string chartType = "bar";
            var categories = new List<string>();
            var data = new List<int>();

            var chartData = await _reservationRepository.GetAll()
                .Where(r => !start.HasValue || DateTime.Compare(r.StartDate, Convert.ToDateTime(start)) >= 0)
                .Where(r => !end.HasValue || DateTime.Compare(r.EndDate, Convert.ToDateTime(end)) <= 0)
                .GroupBy(r => r.Room.Details.BuildingName)
                .Select(g => new
                {
                    g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(a => a.Count)
                .Take(items.HasValue ? Convert.ToInt32(items) : int.MaxValue)
                .ToListAsync();

            chartData.ForEach(x =>
            {
                categories.Add(x.Key);
                data.Add(x.Count);
            });

            var series = new List<ChartDataSeries>() { new ChartDataSeries() { Name = "Reservations", Data = data } };
            var chartDataDto = new ChartDataDto()
            {
                Name = name,
                Title = title,
                ChartType = chartType,
                Categories = categories,
                Series = series
            };

            return chartDataDto;
        }

        public async Task<ChartDataDto> GetDayReservationsChartData(DateTime? start = null, DateTime? end = null)
        {
            const string name = "Days";
            const string title = "Reservations per week day";
            const string chartType = "bar";
            var categories = new List<string>();
            var data = new List<int>();
            var histogram = new Dictionary<DayOfWeek, int>();
            var weekDays = new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };

            weekDays.ForEach(w =>
            {
                histogram.Add(w, 0);
            });

            var reservations = await _reservationRepository.GetAll()
                .Where(r => !start.HasValue || DateTime.Compare(r.StartDate, Convert.ToDateTime(start)) >= 0)
                .Where(r => !end.HasValue || DateTime.Compare(r.EndDate, Convert.ToDateTime(end)) <= 0)
                .ToListAsync();

            reservations.ForEach(r =>
            {
                if (r.StartDate.DayOfWeek != DayOfWeek.Saturday && r.StartDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    histogram[r.StartDate.DayOfWeek]++;
                }
            });

            weekDays.ForEach(w =>
            {
                categories.Add(w.ToString());
                data.Add(histogram[w]);
            });

            var series = new List<ChartDataSeries>() { new ChartDataSeries() { Name = "Reservations", Data = data } };
            var chartDataDto = new ChartDataDto()
            {
                Name = name,
                Title = title,
                ChartType = chartType,
                Categories = categories,
                Series = series
            };

            return chartDataDto;
        }

        public async Task<ChartDataDto> GetPeakHoursReservationsChartData(DateTime? start = null, DateTime? end = null)
        {
            const string name = "Peak Hours";
            const string title = "Peak hours for reservations";
            const string chartType = "column";
            var categories = new List<string>();
            var data = new List<int>();
            var histogram = new Dictionary<int, int>();

            for (var i = 0; i < 24; i++)
            {
                histogram.Add(i, 0);
            }

            var reservations = await _reservationRepository.GetAll()
                .Where(r => !start.HasValue || DateTime.Compare(r.StartDate, Convert.ToDateTime(start)) >= 0)
                .Where(r => !end.HasValue || DateTime.Compare(r.EndDate, Convert.ToDateTime(end)) <= 0)
                .ToListAsync();

            reservations.ForEach(r =>
            {
                histogram[r.StartDate.Hour]++;
            });

            for (var i = 8; i < 19; i++)
            {
                var hour = i < 10 ? $"0{i}" : $"{i}";
                categories.Add($"{hour}:00");
                data.Add(histogram[i]);
            }

            var series = new List<ChartDataSeries>() { new ChartDataSeries() { Name = "Reservations", Data = data } };
            var chartDataDto = new ChartDataDto()
            {
                Name = name,
                Title = title,
                ChartType = chartType,
                Categories = categories,
                Series = series
            };

            return chartDataDto;
        }
    }
}
