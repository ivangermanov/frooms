import Repository from '../repository'

const resource = '/admin/charts'

export default {
  getReservationData (chartName: string, items?: number, start?: string, end?: string) {
    return Repository.get(`${resource}/reservations`, {
      params: {
        chartName,
        items,
        start,
        end
      }
    })
  }
}
