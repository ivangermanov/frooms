<template>
  <v-card>
    <v-container>
      <v-row class="mb-4" justify="space-between">
        <v-col md="4">
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
        <v-col md="5">
          <v-btn-toggle
            v-model="selectedChart"
            mandatory
          >
            <v-btn>
              User
            </v-btn>
            <v-btn>
              Building
            </v-btn>
            <v-btn>
              Day
            </v-btn>
          </v-btn-toggle>
        </v-col>
      </v-row>
      <v-row class="px-4">
        <base-chart
          v-if="!loading"
          :title="chartData[selectedChart].title"
          :chart-type="'bar'"
          :categories="chartData[selectedChart].categories"
          :series="chartData[selectedChart].series"
        />
      </v-row>
    </v-container>
  </v-card>
</template>

<script>
import moment from 'moment'
import BaseChart from './BaseChart.vue'
import ChartSettings from './ChartSettings.vue'
import { RepositoryFactory } from '@/api/repositoryFactory'

const chartRepository = RepositoryFactory.chart

export default {
  components: { BaseChart, ChartSettings },

  data () {
    return {
      loading: true,
      selectedChart: 0,
      settings: {
        items: 3,
        start: moment().startOf('year'),
        end: moment()
      },
      chartData: []
    }
  },

  computed: {
    formattedStartDate () {
      return this.settings.start.toISOString(true) ?? null
    },
    formattedEndDate () {
      return this.settings.end.toISOString(true) ?? null
    }
  },

  mounted () {
    this.fetchChartData()
  },

  methods: {
    async fetchChartData () {
      this.loading = true
      this.chartData = []
      await this.fetchReservationChartData('Users')
      await this.fetchReservationChartData('Buildings')
      await this.fetchReservationChartData('Days')
      this.loading = false
    },
    async fetchReservationChartData (chartName) {
      const { data } = await chartRepository.getReservationData(chartName, this.settings.items, this.formattedStartDate, this.formattedEndDate)
      this.chartData.push(data)
    }
  }
}
</script>
