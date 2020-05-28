using Froom.Data.Dtos;
using Froom.Data.Entities;
using Froom.Data.Repositories.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            var name = "Users";
            var title = "Top users with most reservations";
            var categories = new List<string>();
            var data = new List<int>();

            var reservations = await _reservationRepository.GetAll().ToListAsync();

            var chartData = reservations
                .Where(r => !start.HasValue || DateTime.Compare(r.StartTime, Convert.ToDateTime(start)) >= 0)
                .Where(r => !end.HasValue || DateTime.Compare(r.StartTime.Add(r.Duration), Convert.ToDateTime(end)) <= 0)
                .GroupBy(r => r.User.Name)
                .Select(g => new
                {
                    g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(a => a.Count)
                .Take(items.HasValue ? Convert.ToInt32(items) : int.MaxValue)
                .ToList();

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
                Categories = categories,
                Series = series
            };

            return chartDataDto;
        }

        public async Task<ChartDataDto> GetBuildingReservationsChartData(int? items = null, DateTime? start = null, DateTime? end = null)
        {
            var name = "Buildings";
            var title = "Top buildings with most reservations";
            var categories = new List<string>();
            var data = new List<int>();

            var reservations = await _reservationRepository.GetAll().ToListAsync();

            var chartData = reservations
                .Where(r => !start.HasValue || DateTime.Compare(r.StartTime, Convert.ToDateTime(start)) >= 0)
                .Where(r => !end.HasValue || DateTime.Compare(r.StartTime.Add(r.Duration), Convert.ToDateTime(end)) <= 0)
                .GroupBy(r => r.Room.Details.BuildingName)
                .Select(g => new
                {
                    g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(a => a.Count)
                .Take(items.HasValue ? Convert.ToInt32(items) : int.MaxValue)
                .ToList();

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
                Categories = categories,
                Series = series
            };

            return chartDataDto;
        }

        public async Task<ChartDataDto> GetDayReservationsChartData(int? items = null, DateTime? start = null, DateTime? end = null)
        {
            var name = "Days";
            var title = "Top days with most reservations";
            var categories = new List<string>();
            var data = new List<int>();

            var reservations = await _reservationRepository.GetAll().ToListAsync();

            var chartData = reservations
                .Where(r => !start.HasValue || DateTime.Compare(r.StartTime, Convert.ToDateTime(start)) >= 0)
                .Where(r => !end.HasValue || DateTime.Compare(r.StartTime.Add(r.Duration), Convert.ToDateTime(end)) <= 0)
                .GroupBy(r => r.StartTime.Date)
                .Select(g => new
                {
                    g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(a => a.Count)
                .Take(items.HasValue ? Convert.ToInt32(items) : int.MaxValue)
                .ToList();

            chartData.ForEach(x =>
            {
                categories.Add(x.Key.ToString("dd/MM/yyyy"));
                data.Add(x.Count);
            });

            var series = new List<ChartDataSeries>() { new ChartDataSeries() { Name = "Reservations", Data = data } };
            var chartDataDto = new ChartDataDto()
            {
                Name = name,
                Title = title,
                Categories = categories,
                Series = series
            };

            return chartDataDto;
        }
    }
}
