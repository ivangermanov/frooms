import Repository from './repository'
import { IRoomModel } from '@/types/index'

const resource = '/rooms'

export default {
  getRooms (campus: string, buildingName: string, campusName: string, floor?: string) {
    return Repository.get(`${resource}`, {
      params: {
        campus,
        buildingName,
        campusName,
        floor
      }
    })
  },
  getRoom (id: number | string) {
    return Repository.get(`${resource}/${id}`)
  },
  postRooms (payload: IRoomModel[]) {
    return Repository.post(`${resource}`, payload)
  },
  putRooms (payload: IRoomModel[]) {
    return Repository.put(`${resource}`, payload)
  },
  deleteRooms (payload: IRoomModel[]) {
    return Repository.delete(`${resource}`, { data: payload })
  }
}
