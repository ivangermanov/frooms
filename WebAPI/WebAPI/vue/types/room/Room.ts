import { EShape } from './EShape'
import { IRoom } from './IRoom'
import { IPoint } from './IPoint'

export class Room implements IRoom {
  number: string = '';
  floor: number = -1;
  buildingName: string = '';
  points: IPoint[] = [];
  shape: EShape = EShape.POLYGON;
  capacity?: number;
}
