using System;

namespace Froom.Data.Dtos
{
    public class ReservationRulesDto
    {
        public DateTime CurrentDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DayOfWeek[] AvailableDays { get; set; }
    }
}