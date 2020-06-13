using System;

namespace Froom.Data.Dtos
{
    public class ReservationRulesDto
    {
        public DateTime CurrentDate { get; set; }
        public DateTime MinTime { get; set; }
        public DateTime MaxTime { get; set; }
        public DayOfWeek[] AvailableDays { get; set; }
        public double MinReservationTime { get; set; }
        public double MaxReservationTime { get; set; }
        public DateTime MaxForwardReservationPeriod { get; set; }
    }
}