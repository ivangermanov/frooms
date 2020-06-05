import Repository from '../repository'

const resource = '/admin/charts'

export default {
  getUserReservationsChartData (items?: number, start?: string, end?: string) {
    return Repository.get(`${resource}/reservations/user`, {
      params: {
        items,
        start,
        end
      }
    })
  }
}
