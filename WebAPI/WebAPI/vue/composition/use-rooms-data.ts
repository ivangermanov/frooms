import { reactive, toRefs } from '@vue/composition-api'
import { GeoJSON } from 'leaflet'
import { IRoomDTO, IRoomModel, CreateIRoomModel, IRoomToGeoJSONFeature } from '@/types'

import { RepositoryFactory } from '@/api/repositoryFactory'
const RoomRepository = RepositoryFactory.room

export default function useRoomsData (options: {campusName?: string, buildingName?: string, floorNumber?: string} = {}) {
  const props = reactive({ ...options })
  const data = reactive({
    rooms: {} as { [key: string]: IRoomDTO },
    roomLayers: {} as { [key: string]: GeoJSON.Feature }
  })

  async function getRooms () {
    const { data: json } = await RoomRepository.getRooms(
      props.campusName,
      props.buildingName,
      props.floorNumber
    )
    const rooms: IRoomDTO[] = json
    const newRooms = {} as { [key: string]: IRoomDTO }
    const newRoomLayers = {} as { [key: string]: GeoJSON.Feature }

    rooms.forEach((room) => {
      newRooms[room.number] = room
      newRoomLayers[room.number] = IRoomToGeoJSONFeature(room)
    })
    data.rooms = newRooms
    data.roomLayers = newRoomLayers
  }

  async function postShape (shape: GeoJSON.Feature) {
    const payload = [CreateIRoomModel(shape, props.floorNumber!, props.buildingName!, props.campusName!)]

    await RoomRepository.postRooms(payload).catch(() => {})
  }

  async function putShapes (shapes: GeoJSON) {
    const payload: IRoomModel[] = []
    shapes.eachLayer((layer: any) => {
      const shape = layer.toGeoJSON()
      const room = CreateIRoomModel(shape, props.floorNumber!, props.buildingName!, props.campusName!)
      payload.push(room)
    })

    await RoomRepository.putRooms(payload).catch(() => {})
  }

  async function deleteShapes (shapes: GeoJSON) {
    const payload: IRoomModel[] = []
    shapes.eachLayer((layer: any) => {
      const shape = layer.toGeoJSON()
      const room = CreateIRoomModel(shape, props.floorNumber!, props.buildingName!, props.campusName!)
      payload.push(room)
    })

    await RoomRepository.deleteRooms(payload).catch(() => {})
  }

  return { ...toRefs(data), getRooms, postShape, putShapes, deleteShapes }
}
