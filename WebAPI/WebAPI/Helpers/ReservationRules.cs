using System;

namespace WebAPI.Helpers
{
    public static class ReservationRules
    {
        public static DateTime CurrentDate => DateTime.Today;
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
    }
}