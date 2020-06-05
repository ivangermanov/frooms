import { reactive, toRefs } from '@vue/composition-api'
import {} from '@/types'

import { RepositoryFactory } from '@/api/repositoryFactory'

const AdminChartRepository = RepositoryFactory.adminChart
const ChartRepository = RepositoryFactory.chart

export default function useChartData (itemLimit: number, startDate: string, endDate: string) {
  const state = reactive({
    loading: true as boolean,
    itemLimit: itemLimit as number,
    startDate: startDate as string,
    endDate: endDate as string,
    chartData: {
      user: {},
      peakhours: {},
      building: {},
      day: {}
    } // TODO: Create a type for chart data
  })

  async function getUserReservationsChartData () {
    const { data: chartData }: { data: object } = await AdminChartRepository.getUserReservationsChartData(state.itemLimit, state.startDate, state.endDate)
    state.chartData.user = chartData
  }

  async function getPeakHourReservationChartData () {
    const { data: chartData }: { data: object } = await ChartRepository.getPeakHoursReservationsChartData(state.startDate, state.endDate)
    state.chartData.peakhours = chartData
  }

  async function getBuildingReservationsChartData () {
    const { data: chartData }: { data: object } = await ChartRepository.getBuildingReservationsChartData(state.itemLimit, state.startDate, state.endDate)
    state.chartData.building = chartData
  }

  async function getDayReservationsChartData () {
    const { data: chartData }: { data: object } = await ChartRepository.getDayReservationsChartData(state.startDate, state.endDate)
    state.chartData.day = chartData
  }

  return {
    ...toRefs(state),
    getUserReservationsChartData,
    getPeakHourReservationChartData,
    getBuildingReservationsChartData,
    getDayReservationsChartData
  }
}
