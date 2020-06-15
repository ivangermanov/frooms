import { AxiosResponse } from 'axios'
import Repository from './repository'
import { IReservation, IReservationRules } from '@/types/index'

const resource = '/reservations'

export default {
  postReservation (reservation: IReservation) {
    return Repository.post(`${resource}`, reservation)
  },
  getReservations (userId: string) {
    return Repository.get(`${resource}/user/${userId}`)
  },
  // TODO: Use return value like below in every response for strict types on models
  getRules (): Promise<AxiosResponse<IReservationRules>> {
    return Repository.get(`${resource}/rules`)
  }
}
