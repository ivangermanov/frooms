import { IRoomDTO } from './DTOs/IRoomDTO'
import { EShape } from './EShape'
import { IPoint } from './IPoint'
import { RoomDTO } from './DTOs/RoomDTO'

const GeoJSONToIRoom = (feature: GeoJSON.Feature, shape: EShape): IRoomDTO => {
  const coordinates = (feature.geometry as GeoJSON.Polygon).coordinates.flat()
  const points: IPoint[] = coordinates.map(coord => ({
    x: coord[0],
    y: coord[1]
  }))

  const room = new RoomDTO()
  room.number = feature.properties!.number
  room.shape = shape
  room.points = points

  return room
}

export function CreateIRoomModel (feature: GeoJSON.Feature,
  floorNumber: string,
  buildingName: string,
  campusName: string,
  shape: EShape = EShape.POLYGON,
  capacity: number = 0) {
  const room = GeoJSONToIRoom(feature, shape)
  room.buildingName = buildingName
  room.campusName = campusName
  room.floorNumber = floorNumber
  room.capacity = capacity

  return room
}

export function IRoomToGeoJSONFeature (room: IRoomDTO): GeoJSON.Feature {
  const coordinates: GeoJSON.Position[][] = [
    room.points.map(point => [point.x, point.y])
  ]

  const geometry: GeoJSON.Polygon = {
    type: 'Polygon',
    coordinates
  }

  const feature: GeoJSON.Feature = {
    properties: {
      number: room.number,
      capacity: room.capacity
    },
    type: 'Feature',
    geometry
  }

  return feature
}
