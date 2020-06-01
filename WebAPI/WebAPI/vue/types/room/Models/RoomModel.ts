import { IPoint } from '../IPoint'
import { IRoomModel } from './IRoomModel'

export class RoomModel implements IRoomModel {
  number: string = '';
  buildingName: string = '';
  campusName: string = '';
  floorNumber: string = '';
  floorOrder: number = 0;
  points: IPoint[] = [];
  capacity?: number;
}
