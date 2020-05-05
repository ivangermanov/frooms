import { EShape } from '../EShape'
import { IPoint } from '../IPoint'

export interface IRoomDTO {
  number: string;
  buildingName: string;
  campusName: string;
  floorNumber: string;
  floorOrder: number;
  points: IPoint[];
  shape: EShape;
  capacity?: number;
}
