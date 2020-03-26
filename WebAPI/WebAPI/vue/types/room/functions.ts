import { GeoJSON } from 'leaflet'
import { IRoom } from './IRoom'
import { EShape } from './EShape'
import { IPoint } from './IPoint'

export function GeoJSONToIRooms (geoJSON: GeoJSON): IRoom[] {
  const features = (geoJSON.toGeoJSON() as GeoJSON.FeatureCollection).features
  const rooms = features.map((feature) => {
    // TODO: Always keep as polygon
    const shape = EShape.POLYGON
    const geometry = feature.geometry
    const coordinates: [] = (geometry as any).coordinates.flat()
    const points: IPoint[] = coordinates.map(coord => ({ x: coord[0], y: coord[1] }))

    const room: IRoom = { shape, points }
    return room
  })
  return rooms
}
