import Repository from './repository'
import { IRoom } from '@/types/index'

const resource = '/rooms'

export default {
  get () {
    return Repository.get(`${resource}`)
  },
  getRoom (id: number | string) {
    return Repository.get(`${resource}/${id}`)
  },
  postRooms (payload: IRoom[]) {
    return Repository.post(`${resource}`, payload)
  }
}
