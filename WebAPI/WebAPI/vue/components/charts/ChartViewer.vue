<template>
  <v-container fluid>
    <v-row>
      <v-col>
        <v-btn icon @click="fetchChartData">
          <v-icon>mdi-refresh</v-icon>
        </v-btn>
        <chart-settings
          :items.sync="settings.items"
          :start.sync="settings.start"
          :end.sync="settings.end"
          @update-settings="fetchChartData"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12" md="6" lg="3">
        <base-chart
          v-if="!loading"
          :title="chartData.user.title"
          :chart-type="chartData.user.chartType"
          :categories="chartData.user.categories"
          :series="chartData.user.series"
        />
      </v-col>
      <v-col cols="12" md="6" lg="3">
        <base-chart
          v-if="!loading"
          :title="chartData.peakhours.title"
          :chart-type="chartData.peakhours.chartType"
          :categories="chartData.peakhours.categories"
          :series="chartData.peakhours.series"
        />
      </v-col>
      <v-col cols="12" md="6" lg="3">
        <base-chart
          v-if="!loading"
          :title="chartData.building.title"
          :chart-type="chartData.building.chartType"
          :categories="chartData.building.categories"
          :series="chartData.building.series"
        />
      </v-col>
      <v-col cols="12" md="6" lg="3">
        <base-chart
          v-if="!loading"
          :title="chartData.day.title"
          :chart-type="chartData.day.chartType"
          :categories="chartData.day.categories"
          :series="chartData.day.series"
        />
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from '@vue/composition-api'
import moment from 'moment'
import BaseChart from './BaseChart.vue'
import ChartSettings from './ChartSettings.vue'
import useChartData from '@/composition/use-chart-data'

export default defineComponent({
  components: { BaseChart, ChartSettings },

  setup () {
    const intitialItemLimit = 5
    const intialStartDate = moment().startOf('year').toISOString(true)
    const initialEndDate = moment().startOf('year').add(1, 'year').toISOString(true)

    const {
      loading,
      itemLimit,
      startDate,
      endDate,
      chartData,
      getPeakHourReservationChartData,
      getBuildingReservationsChartData,
      getDayReservationsChartData,
      getUserReservationsChartData
    } = useChartData(intitialItemLimit, intialStartDate, initialEndDate)

    const fetchChartData = async () => {
      loading.value = true
      await getPeakHourReservationChartData()
      await getBuildingReservationsChartData()
      await getDayReservationsChartData()
      await getUserReservationsChartData()
      loading.value = false
    }

    onMounted(
      fetchChartData
    )

    const settings = ref({
      items: itemLimit,
      start: startDate,
      end: endDate
    })

    return {
      loading,
      settings,
      chartData,
      fetchChartData
    }
  }
})
</script>
