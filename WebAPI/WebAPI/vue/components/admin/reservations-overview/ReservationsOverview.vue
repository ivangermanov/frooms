<template>
  <v-card>
    <v-list subheader>
      <v-card-title>
        <v-text-field
          v-model="search"
          append-icon="mdi-magnify"
          label="Search"
          single-line
          hide-details
        />
      </v-card-title>
      <v-data-table
        v-if="typeof reservations != undefined && typeof reservationsHeaders != undefined"
        :headers="reservationsHeaders"
        :items="reservations"
        :search="search"
        multi-sort
        class="elevation-1"
      >
        <template v-slot:item.actions="{ item }">
          <v-icon
            small
            class="mr-2"
            @click="deleteReservation(item)"
          >
            mdi-delete
          </v-icon>
        </template>
      </v-data-table>
    </v-list>
  </v-card>
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
  data () {
    return {
      search: '',
      reservationsHeaders: [
        { text: 'User', value: 'user.name' },
        { text: 'Building', value: 'room.buildingName' },
        { text: 'Room', value: 'room.number' },
        { text: 'Start Date', value: 'startingDate' },
        { text: 'Start Time', value: 'startingTime' },
        { text: 'Duration', value: 'duration' },
        { text: 'Expired', value: 'expired' },
        { text: 'Actions', value: 'actions', sortable: false }

      ]
    }
  },

  methods: {

    deleteReservation (reservation) {
      const index = this.reservations.indexOf(reservation)
      const choice = confirm('Are you sure you want to delete this item?')

      if (choice === true) {
        AdminReservationRepository.deleteReservation(reservation.id)
        this.reservations.splice(index, 1)
      }
    }

  }
}
</script>
