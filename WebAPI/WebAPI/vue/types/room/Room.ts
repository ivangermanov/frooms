import { EShape } from './EShape'
import { IRoom } from './IRoom'
import { IPoint } from './IPoint'

export class Room implements IRoom {
  number: string = '';
  buildingName: string = '';
  floor: string = '';
  points: IPoint[] = [];
  shape: EShape = EShape.POLYGON;
  capacity?: number;
}
