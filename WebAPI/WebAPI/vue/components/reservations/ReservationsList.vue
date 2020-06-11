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
            :headers="headers"
            :items="getReservations()"
            :search="search"
            multi-sort
            class="elevation-1"
          />
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>

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
      headers: [
        { text: 'Building', value: 'room.buildingName' },
        { text: 'Room', value: 'room.number' },
        { text: 'Date', value: 'Date' },
        { text: 'Start Time', value: 'startDate' },
        { text: 'End Time', value: 'endDate' },
        { text: 'Expired', value: 'expired' }

      ],
      overlay: false
    }
  },
  beforeMount () {
    if (this.reservations.length === 0) {
      this.overlay = true
    }
  },
  methods: {
    getReservations () {
      if (this.reservations.length === 0) {
        const data = [
          { room: { number: '2.35', buildingName: 'R1', floorNumber: '2e' }, startDate: '2020-06-11T13:31:00', endDate: '2020-06-11T16:30:00', expired: false },
          { room: { number: '0.15', buildingName: 'R2', floorNumber: '2e' }, startDate: '2020-06-11T13:31:00', endDate: '2020-06-11T16:30:00', expired: true },
          { room: { number: '4.35', buildingName: 'R3', floorNumber: '2e' }, startDate: '2020-06-11T13:31:00', endDate: '2020-06-11T16:30:00', expired: true },
          { room: { number: '2.23', buildingName: 'R1', floorNumber: '2e' }, startDate: '2020-06-11T13:31:00', endDate: '2020-06-11T16:30:00', expired: true },
          { room: { number: '1.11', buildingName: 'E1', floorNumber: '2e' }, startDate: '2020-06-11T13:31:00', endDate: '2020-06-11T16:30:00', expired: true },
          { room: { number: '2.22', buildingName: 'R10', floorNumber: '2e' }, startDate: '2020-06-11T13:31:00', endDate: '2020-06-11T16:30:00', expired: false },
          { room: { number: '3.34', buildingName: 'E5', floorNumber: '2e' }, startDate: '2020-06-11T13:31:00', endDate: '2020-06-11T16:30:00', expired: false },
          { room: { number: '0.01', buildingName: 'E11', floorNumber: '2e' }, startDate: '2020-06-11T13:31:00', endDate: '2020-06-11T16:30:00', expired: true }
        ]
        return data
      }
      return this.reservations
    }
  }
}

</script>
