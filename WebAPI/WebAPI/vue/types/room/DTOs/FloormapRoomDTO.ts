import { IPoint } from '../IPoint'
import { IFloormapRoomDTO } from './IFloormapRoomDTO'

export class FloormapRoomDTO implements IFloormapRoomDTO {
  number: string = '';
  buildingName: string = '';
  campusName: string = '';
  floorNumber: string = '';
  floorOrder: number = 0;
  points: IPoint[] = [];
  isAvailable: boolean = true;
  capacity?: number;
}
