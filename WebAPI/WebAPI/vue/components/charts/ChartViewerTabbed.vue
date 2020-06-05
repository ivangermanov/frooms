<template>
  <v-container>
    <v-row>
      <v-col>
        <v-btn-toggle
          v-model="selectedChartIndex"
          mandatory
        >
          <v-btn>
            Peak Hours
          </v-btn>
          <v-btn>
            Building
          </v-btn>
          <v-btn>
            Day
          </v-btn>
        </v-btn-toggle>
        <v-btn icon @click="fetchChartData">
          <v-icon>mdi-refresh</v-icon>
        </v-btn>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <base-chart
          v-if="!loading"
          :title="chartData[selectedChart].title"
          :chart-type="chartData[selectedChart].chartType"
          :categories="chartData[selectedChart].categories"
          :series="chartData[selectedChart].series"
        />
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref, computed } from '@vue/composition-api'
import moment from 'moment'
import useChartData from '@/composition/use-chart-data'
import BaseChart from '@/components/charts/BaseChart.vue'

export default defineComponent({
  components: { BaseChart },

  setup () {
    const selectedChartIndex = ref(0)
    const intitialItemLimit = 5
    const intialStartDate = moment().startOf('year').toISOString(true)
    const initialEndDate = moment().toISOString(true)

    const {
      loading,
      chartData,
      getPeakHourReservationChartData,
      getBuildingReservationsChartData,
      getDayReservationsChartData
    } = useChartData(intitialItemLimit, intialStartDate, initialEndDate)

    const fetchChartData = async () => {
      loading.value = true
      await getPeakHourReservationChartData()
      await getBuildingReservationsChartData()
      await getDayReservationsChartData()
      loading.value = false
    }

    onMounted(
      fetchChartData
    )

    const selectedChart = computed(() => {
      switch (selectedChartIndex.value) {
        case 0:
          return 'peakhours'
        case 1:
          return 'building'
        case 2:
          return 'day'
      }
    })

    return {
      selectedChartIndex,
      selectedChart,
      loading,
      chartData,
      fetchChartData
    }
  }
})
</script>
