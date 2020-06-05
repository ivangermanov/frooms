<template>
  <v-container>
    <v-row>
      <v-col md="7">
        <reservations-list />
      </v-col>
      <v-col md="5">
        <chart-viewer-tabbed />
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { defineComponent } from '@vue/composition-api'
import ReservationsList from '@/components/reservations/ReservationsList.vue'
import ChartViewerTabbed from '@/components/charts/ChartViewerTabbed.vue'

export default defineComponent({
  components: {
    ReservationsList, ChartViewerTabbed
  }
})
</script>
