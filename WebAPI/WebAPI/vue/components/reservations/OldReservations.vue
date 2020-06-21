<template>
  <v-container>
    <v-row>
      <v-col cols="12">
        <v-card>
          <v-card-title>
            Reservations
            <v-spacer />
            <v-text-field
              v-model="search"
              append-icon="mdi-magnify"
              label="Search reservations"
              single-line
              hide-details
            />
          </v-card-title>
          <v-overlay
            v-if="overlay"
            absolute
            color="primary"
          >
            <v-card max-width="374">
              <v-card-title class="headline">
                Welcome to Froom!
              </v-card-title>
              <v-card-text>
                <p>
                  Froom is an application to book rooms. Head over to the Floor map page to make your first reservation!
                </p>
              </v-card-text>
              <v-card-actions>
                <v-spacer />
                <v-btn color="primary" nuxt to="/floor-map">
                  Continue
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-overlay>
          <v-data-table
            :headers="reservationsHeaders"
            :items="getReservations()"
            :search="search"
          >
            <template v-slot:item.expired="{ item }">
              <v-icon
                v-if="item.expired"
                small
              >
                mdi-checkbox-marked-circle
              </v-icon>
            </template>
            <template v-slot:item.isCancelled="{ item }">
              <v-icon
                v-if="item.isCancelled"
                small
              >
                mdi-checkbox-marked-circle
              </v-icon>
            </template>
            <template v-slot:item.actions="{ item }">
              <v-icon
                small
                @click="cancelReservation(item)"
              >
                mdi-delete
              </v-icon>
            </template>
          </v-data-table>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { RepositoryFactory } from '@/api/repositoryFactory'

const AdminReservationRepository = RepositoryFactory.adminReservation

export default {
  props: {
    reservations: {
      type: Array,
      required: true
    }
  },
  data: () => {
    return {
      search: '',
      reservationsHeaders: [
        { text: 'Building', value: 'room.buildingName' },
        { text: 'Room', value: 'room.number' },
        { text: 'Start Date', value: 'startingDate' },
        { text: 'Start Time', value: 'startingTime' },
        { text: 'End Date', value: 'endingDate' },
        { text: 'End Time', value: 'endingTime' },
        { text: 'Expired', value: 'isExpired' },
        { text: 'Cancelled', value: 'isCancelled' },
        { text: 'Actions', value: 'actions', sortable: false }
      ],
      overlay: false
    }
  },
  onMounted () {
    if (this.reservations.length === 0) {
      this.overlay = true
    }
  },
  methods: {
    cancelReservation (reservation) {
      const index = this.reservations.indexOf(reservation)
      const choice = confirm('Are you sure you want to cancel this reservation?')

      if (choice === true) {
        AdminReservationRepository.deleteReservation(reservation.id)
        this.reservations[index].isCancelled = true
      }
    },
    getReservations () {
      if (this.reservations.length === 0) {
        const data = [
          { room: { number: '2.35', buildingName: 'R1', floorNumber: '2e' }, startingDate: '2020-06-11', startingTime: '13:31', endingDate: '2020-06-11', endingTime: '16:30', expired: false, isCancelled: false },
          { room: { number: '0.15', buildingName: 'R2', floorNumber: '2e' }, startingDate: '2020-06-11', startingTime: '13:31', endingDate: '2020-06-11', endingTime: '16:30', expired: true, isCancelled: true },
          { room: { number: '4.35', buildingName: 'R3', floorNumber: '2e' }, startingDate: '2020-06-11', startingTime: '13:31', endingDate: '2020-06-11', endingTime: '16:30', expired: true, isCancelled: false },
          { room: { number: '2.23', buildingName: 'R1', floorNumber: '2e' }, startingDate: '2020-06-11', startingTime: '13:31', endingDate: '2020-06-11', endingTime: '16:30', expired: true, isCancelled: true },
          { room: { number: '1.11', buildingName: 'E1', floorNumber: '2e' }, startingDate: '2020-06-11', startingTime: '13:31', endingDate: '2020-06-11', endingTime: '16:30', expired: true, isCancelled: false },
          { room: { number: '2.22', buildingName: 'R10', floorNumber: '2e' }, startingDate: '2020-06-11', startingTime: '13:31', endingDate: '2020-06-11', endingTime: '16:30', expired: false, isCancelled: false },
          { room: { number: '3.34', buildingName: 'E5', floorNumber: '2e' }, startingDate: '2020-06-11', startingTime: '13:31', endingDate: '2020-06-11', endingTime: '16:30', expired: false, isCancelled: true },
          { room: { number: '0.01', buildingName: 'E11', floorNumber: '2e' }, startingDate: '2020-06-11', startingTime: '13:31', endingDate: '2020-06-11', endingTime: '16:30', expired: true, isCancelled: false }
        ]
        return data
      }
      return this.reservations
    }
  }
}

</script>
