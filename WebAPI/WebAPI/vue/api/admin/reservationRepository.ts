import Repository from '../repository'
import { IReservationAdmin } from '@/types/index'

const resource = '/admin/reservations'

export default {
  getAllReservations () {
    return Repository.get(`${resource}/`)
  },

  deleteReservation (id: number) {
    return Repository.delete(`${resource}/${id}`)
  },

  updateReservation (reservationToChange: IReservationAdmin) {
    console.log(reservationToChange)
    return Repository.put(`${resource}`, reservationToChange)
  }
}
