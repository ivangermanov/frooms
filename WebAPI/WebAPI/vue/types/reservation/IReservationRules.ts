import { DayOfWeek } from './DayOfWeek'

export interface IReservationRules {
    currentDate: string;
    minTime: string;
    maxTime: string;
    availableDays: DayOfWeek[];
    minReservationTime: number;
    maxReservationTime: number;
    maxForwardReservationPeriod: number;
  }
