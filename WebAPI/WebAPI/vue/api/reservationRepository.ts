import Repository from './repository'
import { IReservation } from '@/types/index'

const resource = '/reservations'

export default {
  postReservation (reservation: IReservation) {
    return Repository.post(`${resource}`, reservation)
  },
  getReservations (userId: string) {
    return Repository.get(`${resource}/user/${userId}`)
  },
  getRules () {
    return Repository.get(`${resource}/rules`)
  }
}
