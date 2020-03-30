import { EShape } from './EShape'
import { IPoint } from './IPoint'

export interface IRoom {
  number: string;
  floor: number;
  buildingName: string;
  points: IPoint[];
  shape: EShape;
  capacity?: number;
}
