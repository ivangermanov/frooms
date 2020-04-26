import { EShape } from '../EShape'
import { IPoint } from '../IPoint'
import { IRoomDTO } from './IRoomDTO'

export class RoomDTO implements IRoomDTO {
  number: string = '';
  buildingName: string = '';
  campusName: string = '';
  floorNumber: string = '';
  floorOrder: number = 0;
  points: IPoint[] = [];
  shape: EShape = EShape.POLYGON;
  capacity?: number;
}
