<template>
  <v-card>
    <v-list subheader>
      <v-card-title>
        <!-- Reservations List
        <v-spacer /> -->
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
        v-model="selected"
        :single-select="singleSelect"
        :headers="reservationsHeaders"
        :items="reservations"
        :search="search"
        multi-sort
        item-key="id"
        show-select
        class="elevation-1"
      />
      <template v-slot:top>
        <v-switch v-model="singleSelect" label="Single select" class="pa-3" />
      </template>
    </v-list>
  </v-card>
</template>

<script>
import moment from 'moment'
import { RepositoryFactory } from '@/api/repositoryFactory'

const AdminReservationRepository = RepositoryFactory.adminReservation

export default {

  data () {
    return {
      search: '',
      selected: [],
      singleSelect: false,
      reservations: undefined,
      reservationsHeaders: [
        { text: 'Index', value: 'id' },
        { text: 'User', value: 'user.name' },
        { text: 'Building', value: 'room.buildingName' },
        { text: 'Room', value: 'room.number' },
        { text: 'Start Date', value: 'startingDate' },
        { text: 'Start Time', value: 'startingTime' },
        { text: 'Duration', value: 'duration' },
        { text: 'Expired', value: 'expired' }

      ]
    }
  },

  mounted () {
    this.fetchReservations()
  },

  methods: {
    async fetchReservations () {
      const { data } = await AdminReservationRepository.getAllReservations()
      this.reservations = data
      this.reservations.map((x, index) => {
        x.id = index
        x.startingDate = moment(x.startingTime).format('DD/MM/YYYY')
        x.startingTime = moment(x.startingTime).format('HH:MM:SS')
        return x
      })
    }

  }
}
</script>
