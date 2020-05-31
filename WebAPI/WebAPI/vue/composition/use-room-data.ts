import { reactive, toRefs } from '@vue/composition-api'
import { GeoJSON } from 'leaflet'
import {
  IFloormapRoomDTO,
  IRoomModel,
  CreateIRoomModel,
  IRoomToGeoJSONFeature,
  IFloor
} from '@/types'

import { RepositoryFactory } from '@/api/repositoryFactory'
const RoomRepository = RepositoryFactory.room
const FloorRepository = RepositoryFactory.floor
const FontysApiRepository = RepositoryFactory.fontysApi

export default function useRoomData (
  props: {
    campusName?: string;
    buildingName?: string;
    floorNumber?: string;
    startDate?: string;
    endDate?: string;
  } = {}
) {
  const data = reactive({
    rooms: {} as { [key: string]: IFloormapRoomDTO },
    floors: [] as IFloor[],
    roomLayers: {} as { [key: string]: GeoJSON.Feature }
  })

  async function getFloors () {
    // TODO: Make IFloor TypeScript interface
    const {
      data: json
    }: { data: Array<any> } = await FloorRepository.getFloors(
      props.buildingName!
    )
    const floors = await Promise.all(json.map(async (floor) => {
      const url = await FontysApiRepository.getLocationMapImage(
        props.campusName!,
        props.buildingName!,
        floor.number!
      ).catch()

      return {
        ...floor,
        url
      }
    })) as IFloor[]

    data.floors = floors
  }

  async function getRooms () {
    const { data: rooms }: { data: IFloormapRoomDTO[] } = await RoomRepository.getFloormapRooms(
      props.campusName,
      props.buildingName,
      props.floorNumber,
      props.startDate,
      props.endDate
    )
    const newRooms = {} as { [key: string]: IFloormapRoomDTO }
    const newRoomLayers = {} as { [key: string]: GeoJSON.Feature }

    rooms.forEach((room) => {
      newRooms[room.number] = room
      newRoomLayers[room.number] = IRoomToGeoJSONFeature(room)
    })
    data.rooms = newRooms
    data.roomLayers = newRoomLayers
  }

  async function postShape (shape: GeoJSON.Feature) {
    const payload = [
      CreateIRoomModel(
        shape,
        props.floorNumber!,
        props.buildingName!,
        props.campusName!
      )
    ]

    await RoomRepository.postRooms(payload).catch(() => {})
  }

  async function putShapes (shapes: GeoJSON) {
    const payload: IRoomModel[] = []
    shapes.eachLayer((layer: any) => {
      const shape = layer.toGeoJSON()
      const room = CreateIRoomModel(
        shape,
        props.floorNumber!,
        props.buildingName!,
        props.campusName!
      )
      payload.push(room)
    })

    await RoomRepository.putRooms(payload).catch(() => {})
  }

  async function deleteShapes (shapes: GeoJSON) {
    const payload: IRoomModel[] = []
    shapes.eachLayer((layer: any) => {
      const shape = layer.toGeoJSON()
      const room = CreateIRoomModel(
        shape,
        props.floorNumber!,
        props.buildingName!,
        props.campusName!
      )
      payload.push(room)
    })

    await RoomRepository.deleteRooms(payload).catch(() => {})
  }

  return {
    ...toRefs(data),
    getFloors,
    getRooms,
    postShape,
    putShapes,
    deleteShapes
  }
}
