import { IPoint } from '../IPoint'

export interface IFloormapRoomDTO {
  number: string;
  buildingName: string;
  campusName: string;
  floorNumber: string;
  floorOrder: number;
  points: IPoint[];
  isAvailable: boolean;
  capacity?: number;
}
