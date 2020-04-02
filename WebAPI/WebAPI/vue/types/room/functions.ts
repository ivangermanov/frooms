import { Polyline } from 'leaflet'
import { IRoom } from './IRoom'
import { EShape } from './EShape'
import { IPoint } from './IPoint'
import { Room } from './Room'

export function CreateIRoom (
  polyline: Polyline,
  number: string,
  floor: number,
  buildingName: string,
  shape: EShape = EShape.POLYGON,
  capacity: number = 0
): IRoom {
  const GeoJSONToIRoom = (polyline: Polyline): IRoom => {
    const feature = polyline.toGeoJSON()
    const geometry = feature.geometry

    const coordinates = geometry.coordinates.flat()
    const points: IPoint[] = coordinates.map(coord => ({
      x: coord[0],
      y: coord[1]
    }))

    const room = new Room()
    room.shape = shape
    room.points = points

    return room
  }

  const room = GeoJSONToIRoom(polyline)
  room.number = number
  room.floor = floor
  room.buildingName = buildingName
  room.capacity = capacity

  return room
}

export function IRoomToGeoJSONFeature (room: IRoom): GeoJSON.Feature {
  const coordinates: GeoJSON.Position[] = room.points.map(point => [point.x, point.y])

  const geometry: GeoJSON.LineString = {
    type: 'LineString',
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
