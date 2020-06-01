import Repository from './repository'
import { IRoomModel } from '@/types/index'

const resource = '/rooms'

export default {
  getFloormapRooms (campusName?: string, buildingName?: string, floor?: string, fromDate?: string,
    toDate?: string) {
    return Repository.get(
      `${resource}`,
      {
        params: {
          campusName,
          buildingName,
          floor,
          fromDate,
          toDate
        }
      }
    )
  },
  getRoom (id: number | string) {
    return Repository.get(`${resource}/${id}`)
  },
  getAvailableRooms (
    campus: string,
    buildingName: string,
    floor: string,
    fromDate: string,
    toDate: string
  ) {
    return Repository.get(
      `${resource}/available/${campus}/${buildingName}/${floor}`,
      {
        params: {
          fromDate,
          toDate
        }
      }
    )
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
