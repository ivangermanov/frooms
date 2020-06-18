using System;
using System.Linq;

namespace WebAPI.Helpers
{
    public static class ReservationRules
    {
        public static DateTime CurrentDate => DateTime.Now;
        public static DateTime MinTime => DateTime.Today.AddHours(9);
        public static DateTime MaxTime => DateTime.Today.AddHours(17);

        public static DayOfWeek[] AvailableDays => new[]
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday
        };

        public static TimeSpan MinReservationTime => TimeSpan.FromMinutes(15);
        public static TimeSpan MaxReservationTime => TimeSpan.FromHours(3);
        public static TimeSpan MaxForwardReservationPeriod => TimeSpan.FromDays(90);

        public static bool IsValid(DateTime startDate, DateTime endDate) =>
            startDate >= RoundDown(CurrentDate, TimeSpan.FromMinutes(1)) &&
            endDate - CurrentDate <= MaxForwardReservationPeriod &&
            endDate - startDate >= MinReservationTime &&
            endDate - startDate <= MaxReservationTime &&
            startDate.Hour >= MinTime.Hour &&
            endDate.Hour <= MaxTime.Hour &&
            AvailableDays.Contains(startDate.DayOfWeek) &&
            AvailableDays.Contains(endDate.DayOfWeek);

        private static DateTime RoundDown(DateTime dt, TimeSpan d)
        {
            var delta = dt.Ticks % d.Ticks;
            return new DateTime(dt.Ticks - delta, dt.Kind);
        }
    }
}