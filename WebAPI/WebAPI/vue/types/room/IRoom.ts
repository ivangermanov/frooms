import { EShape } from './EShape'
import { IPoint } from './IPoint'

export interface IRoom {
  number: string;
  buildingName: string;
  buildingCampus: string,
  floor: string;
  points: IPoint[];
  shape: EShape;
  capacity?: number;
}
