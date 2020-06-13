export interface IReservationRules {
    currentDate: string;
    minTime: string;
    maxTime: string;
    availableDates: number[];
    minReservationTime: number;
    maxReservationTime: number;
    maxForwardReservationPeriod: string;
  }
