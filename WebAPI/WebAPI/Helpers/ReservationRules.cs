using System;

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
    }
}