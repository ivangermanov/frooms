<template>
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
    <v-data-table
      :headers="headers"
      :items="reservations"
      :search="search"
      multi-sort
      class="elevation-1"
    />
  </v-card>
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

      ]
    }
  }
}

</script>
