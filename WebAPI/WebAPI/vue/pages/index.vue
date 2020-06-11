<template>
  <v-container>
    <v-row>
      <v-col md="7" style="width: 100%">
        <reservations-list :reservations="reservations" />
      </v-col>
      <v-col md="5">
        <chart-viewer-tabbed />
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import ReservationsList from '@/components/reservations/ReservationsList.vue'
import ChartViewerTabbed from '@/components/charts/ChartViewerTabbed.vue'
import { RepositoryFactory } from '@/api/repositoryFactory'

const ReservationRepository = RepositoryFactory.reservation

export default {
  components: {
    ReservationsList, ChartViewerTabbed
  },
  data () {
    return { reservations: [] }
  },
  beforeMount () {
    this.getUserReservations()
  },
  methods: {
    async getUserReservations () {
      const { data } = await ReservationRepository.getReservations(this.$store.state.user.info.sub)
      this.reservations = data
    }
  }
}
</script>
