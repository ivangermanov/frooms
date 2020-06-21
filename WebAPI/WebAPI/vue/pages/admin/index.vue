<template>
  <v-layout column justify-center align-center>
    <v-tabs
      v-model="tab"
      background-color="primary"
      dark
    >
      <v-tab>
        Users
      </v-tab>
      <v-tab>
        Reservations
      </v-tab>
      <v-tab>
        Statistics
      </v-tab>
    </v-tabs>

    <v-tabs-items v-model="tab" style="width:100%">
      <v-tab-item>
        <user-overview :users="users" />
      </v-tab-item>
      <v-tab-item>
        <reservations-overview :input-reservations="reservations" :input-users="users" />
      </v-tab-item>
      <v-tab-item>
        <chart-viewer />
      </v-tab-item>
    </v-tabs-items>
  </v-layout>
</template>

<script lang="ts">
import Vue from 'vue'
import moment from 'moment'
import UserOverview from '@/components/admin/user-overview/UserOverview.vue'
import ReservationsOverview from '@/components/admin/reservations-overview/ReservationsOverview.vue'
import ChartViewer from '@/components/charts/ChartViewer.vue'
import { RepositoryFactory } from '@/api/repositoryFactory'

const AdminUserRepository = RepositoryFactory.adminUser
const AdminReservationRepository = RepositoryFactory.adminReservation

export default Vue.extend({
  layout: 'admin',
  components: { UserOverview, ChartViewer, ReservationsOverview },
  data () {
    return {
      tab: null,
      users: [],
      reservations: []
    }
  },
  beforeMount () {
    this.getUsers()
    this.getAllReservationsForAdmin()
  },
  methods: {
    async getUsers () {
      const { data } = await AdminUserRepository.getUsers()
      this.users = data
    },
    async getAllReservationsForAdmin () {
      const { data } = await AdminReservationRepository.getAllReservations()
      this.reservations = data.map((reservation:any) => {
        reservation.startingDate = moment(reservation.startDate.split('T')[0]).format('DD/MM/YYYY')
        reservation.startingTime = moment(reservation.startDate.split('T')[1], 'hh:mm').format('hh:mm')
        reservation.endingDate = moment(reservation.endDate.split('T')[0]).format('DD/MM/YYYY')
        reservation.endingTime = moment(reservation.endDate.split('T')[1], 'hh:mm').format('hh:mm')
        return reservation
      })
    }
  }
})
</script>
