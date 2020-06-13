using System;

namespace WebAPI.Helpers
{
    public class ReservationRules
    {
        public DateTime CurrentDate => DateTime.Today;
        public DateTime StartTime => DateTime.Today.AddHours(9);
        public DateTime EndTime => DateTime.Today.AddHours(17);

        public DayOfWeek[] AvailableDays => new[]
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday
        };
    }
}