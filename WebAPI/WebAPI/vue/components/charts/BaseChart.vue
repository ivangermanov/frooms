<template>
  <chart :options="chartOptions" />
</template>

<script>
import { Chart } from 'highcharts-vue'

export default {
  components: { Chart },

  data () {
    return {
      chartOptions: {
        chart: {
          type: 'column'
        },
        title: {
          text: 'Monthly Room Reservations'
        },
        subtitle: {
          text: 'Source: Froom Application'
        },
        xAxis: {
          categories: [
            'Jan',
            'Feb',
            'Mar',
            'Apr',
            'May',
            'Jun',
            'Jul',
            'Aug',
            'Sep',
            'Oct',
            'Nov',
            'Dec'
          ],
          crosshair: true
        },
        yAxis: {
          min: 0,
          title: {
            text: 'Reservations made'
          }
        },
        plotOptions: {
          column: {
            pointPadding: 0.2,
            borderWidth: 0
          }
        },
        series: [{
          name: 'Reservations',
          data: [49, 71, 106, 129, 144, 176, 135, 148, 216, 194, 95, 54]

        }],
        credits: {
          enabled: false
        }
      }
    }
  }
}
</script>
