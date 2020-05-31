import { IRoomDTO } from './IRoomDTO'

export class RoomDTO implements IRoomDTO {
  number: string = '';
  buildingName: string = '';
  campusName: string = '';
  floorNumber: string = '';
  capacity?: number;
}
