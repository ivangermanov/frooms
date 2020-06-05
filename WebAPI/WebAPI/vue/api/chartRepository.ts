import Repository from './repository'

const resource = '/charts'

export default {
  getBuildingReservationsChartData (items?: number, start?: string, end?: string) {
    return Repository.get(`${resource}/reservations/building`, {
      params: {
        items,
        start,
        end
      }
    })
  },

  getDayReservationsChartData (start?: string, end?: string) {
    return Repository.get(`${resource}/reservations/day`, {
      params: {
        start,
        end
      }
    })
  },

  getPeakHoursReservationsChartData (start?: string, end?: string) {
    return Repository.get(`${resource}/reservations/peak-hours`, {
      params: {
        start,
        end
      }
    })
  }
}
