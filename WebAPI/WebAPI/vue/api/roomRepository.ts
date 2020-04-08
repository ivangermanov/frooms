import Repository from './repository'
import { IRoom } from '@/types/index'

const resource = '/rooms'

export default {
  getRooms (campus: string, buildingName: string, floor?: number) {
    return Repository.get(`${resource}`, {
      params: {
        campus,
        buildingName,
        floor
      }
    })
  },
  getRoom (id: number | string) {
    return Repository.get(`${resource}/${id}`)
  },
  postRooms (payload: IRoom[]) {
    return Repository.post(`${resource}`, payload)
  },
  putRooms (payload: IRoom[]) {
    return Repository.put(`${resource}`, payload)
  }
}
