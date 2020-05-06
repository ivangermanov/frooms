import Repository from './repository'
import { IReservation } from '@/types/index'

const resource = '/reservations'

export default {
  postReservation (reservation: IReservation) {
    return Repository.post(`${resource}`, reservation)
  }
}
