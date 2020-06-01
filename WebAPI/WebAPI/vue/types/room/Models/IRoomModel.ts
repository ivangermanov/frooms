import { IPoint } from '../IPoint'

export interface IRoomModel {
  number: string;
  buildingName: string;
  campusName: string;
  floorNumber: string;
  points: IPoint[];
  capacity?: number;
}
