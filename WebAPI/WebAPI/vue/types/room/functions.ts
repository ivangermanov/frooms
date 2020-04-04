import { Polyline } from 'leaflet'
import { IRoom } from './IRoom'
import { EShape } from './EShape'
import { IPoint } from './IPoint'
import { Room } from './Room'

export function CreateIRoom (
  feature: GeoJSON.Feature,
  floor: number,
  buildingName: string,
  shape: EShape = EShape.POLYGON,
  capacity: number = 0
): IRoom {
  const GeoJSONToIRoom = (feature: GeoJSON.Feature): IRoom => {
    const coordinates = feature.geometry.coordinates.flat()
    const points: IPoint[] = coordinates.map(coord => ({
      x: coord[0],
      y: coord[1]
    }))

    const room = new Room()
    room.number = feature.properties!.number
    room.shape = shape
    room.points = points

    return room
  }

  const room = GeoJSONToIRoom(feature)
  room.floor = floor
  room.buildingName = buildingName
  room.capacity = capacity

  return room
}

export function IRoomToGeoJSONFeature (room: IRoom): GeoJSON.Feature {
  const coordinates: GeoJSON.Position[][] = [room.points.map(point => [point.x, point.y])]

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
