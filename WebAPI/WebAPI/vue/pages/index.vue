<template>
  <v-container>
    <v-row>
      <v-col md="8" style="width: 100%">
        <reservations-list :reservations="reservations" />
      </v-col>
      <v-col md="4">
        <chart-viewer-tabbed />
      </v-col>
      <v-overlay
        v-if="tutorial && !$vuetify.breakpoint.xs"
        absolute
        color="primary"
      >
        <user-tutorial @close="close" />
      </v-overlay>
    </v-row>
  </v-container>
</template>

<script>
import moment from 'moment'
import ReservationsList from '@/components/reservations/ReservationsList.vue'
import ChartViewerTabbed from '@/components/charts/ChartViewerTabbed.vue'
import { RepositoryFactory } from '@/api/repositoryFactory'
import UserTutorial from '@/components/tutorials/UserTutorialComponent.vue'

const ReservationRepository = RepositoryFactory.reservation

export default {
  components: {
    ReservationsList, ChartViewerTabbed, UserTutorial
  },
  data () {
    return { reservations: [], tutorial: false }
  },
  mounted () {
    this.getUserReservations()
  },
  methods: {
    async getUserReservations () {
      const { data } = await ReservationRepository.getReservations(this.$store.state.user.info.sub)
      this.reservations = data.map((reservation) => {
        reservation.startingDate = moment(reservation.startDate.split('T')[0]).format('DD/MM/YYYY')
        reservation.startingTime = moment(reservation.startDate.split('T')[1], 'hh:mm').format('hh:mm')
        reservation.endingDate = moment(reservation.endDate.split('T')[0]).format('DD/MM/YYYY')
        reservation.endingTime = moment(reservation.endDate.split('T')[1], 'hh:mm').format('hh:mm')
        return reservation
      })
      if (this.reservations.length === 0) {
        this.tutorial = true
      }
    },
    close () {
      this.tutorial = false
    }
  }
}
</script>
