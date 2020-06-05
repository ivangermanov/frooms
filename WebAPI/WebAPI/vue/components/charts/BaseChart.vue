<template>
  <chart :options="chartOptions" />
</template>

<script>
import { Chart } from 'highcharts-vue'

export default {
  components: { Chart },

  props: {
    title: {
      type: String,
      required: false,
      default () {
        return 'Base Chart Title'
      }
    },
    chartType: {
      type: String,
      required: false,
      default () {
        return 'column'
      }
    },
    categories: {
      type: Array,
      required: true
    },
    series: {
      type: Array,
      required: true
    }
  },

  data () {
    return {
      chartOptions: {
        chart: {
          type: this.chartType
        },
        title: {
          text: this.title
        },
        xAxis: {
          categories: this.categories,
          crosshair: true
        },
        yAxis: {
          min: 0,
          title: {
            text: 'Reservation Count'
          }
        },
        plotOptions: {
          column: {
            pointPadding: 0.1,
            borderWidth: 0,
            groupPadding: 0
          }
        },
        series: this.series,
        credits: {
          enabled: false
        }
      }
    }
  },

  watch: {
    title (newValue) {
      this.chartOptions.title.text = newValue
    },
    series (newValue) {
      this.chartOptions.series = newValue
    },
    chartType (newValue) {
      this.chartOptions.chart.type = newValue
    },
    categories (newValue) {
      this.chartOptions.xAxis.categories = newValue
    }
  }
}
</script>
