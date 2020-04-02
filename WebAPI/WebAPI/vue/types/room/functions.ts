import { GeoJSON } from 'leaflet'
import { IRoom } from './IRoom'
import { EShape } from './EShape'
import { IPoint } from './IPoint'
import { Room } from './Room'

export function CreateIRoom (
  geoJSON: GeoJSON,
  number: string,
  floor: number,
  buildingName: string,
  shape: EShape = EShape.POLYGON,
  capacity: number = 0
): IRoom {
  const GeoJSONToIRoom = (geoJSON: GeoJSON): IRoom => {
    const feature = geoJSON.toGeoJSON() as GeoJSON.Feature
    const geometry = feature.geometry

    const coordinates: [] = (geometry as any).coordinates.flat()
    const points: IPoint[] = coordinates.map(coord => ({
      x: coord[0],
      y: coord[1]
    }))

    const room = new Room()
    room.shape = shape
    room.points = points

    return room
  }

  const room = GeoJSONToIRoom(geoJSON)
  room.number = number
  room.floor = floor
  room.buildingName = buildingName
  room.capacity = capacity

  return room
}

export function IRoomToGeoJSON (room: IRoom) {

}
