import Repository from '../repository'

const resource = '/admin/reservations'

export default {
  getAllReservations () {
    return Repository.get(`${resource}/`)
  },

  deleteReservation (id: number) {
    return Repository.delete(`${resource}/${id}`)
  }
}
