import { IFloormapRoomDTO } from './DTOs/IFloormapRoomDTO'
import { IPoint } from './IPoint'
import { FloormapRoomDTO } from './DTOs/FloormapRoomDTO'

const GeoJSONToIFloormapRoom = (feature: GeoJSON.Feature): IFloormapRoomDTO => {
  const coordinates = (feature.geometry as GeoJSON.Polygon).coordinates.flat()
  const points: IPoint[] = coordinates.map(coord => ({
    x: coord[0],
    y: coord[1]
  }))

  const room = new FloormapRoomDTO()
  room.number = feature.properties!.number
  room.points = points

  return room
}

export function CreateIRoomModel (feature: GeoJSON.Feature,
  floorNumber: string,
  buildingName: string,
  campusName: string,
  capacity: number = 0) {
  const room = GeoJSONToIFloormapRoom(feature)
  room.buildingName = buildingName
  room.campusName = campusName
  room.floorNumber = floorNumber
  room.capacity = capacity

  return room
}

export function IRoomToGeoJSONFeature (room: IFloormapRoomDTO): GeoJSON.Feature {
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
