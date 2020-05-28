<template>
  <div id="OverviewList">
    <div class="reservations">
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
    </div>
  </div>
</template>

<script>
// import { RepositoryFactory } from '@/api/repositoryFactory'
// import reservationRepository from '../../api/reservationRepository'

// const OverviewReservationsRepository = RepositoryFactory.reservation

export default {

  name: 'OverviewList',

  data: () => {
    return {
      search: '',
      headers: [
        { text: 'Building', value: 'Building' },
        { text: 'Room', value: 'Room' },
        { text: 'Date', value: 'Date' },
        { text: 'Start Tine', value: 'StartTime' },
        { text: 'End Time', value: 'EndTime' },
        { text: 'Duration', value: 'Duration' },
        { text: 'Expired', value: 'Expired' }

      ],
      // reservations: [],
      // beforeMount()
      // {
      //   this.fetchReservations()
      // },

      // methods:
      // {
      //   async fetchReservations()
      //   {
      //     const { data } = await reservationRepository.postReservation()
      //     this.reservations = data
      //   }
      // }
      reservations: [
        { Building: 'R1', Room: '2.40', Date: '25-05-2020', StartTime: '12:00', EndTime: '14:00', Duration: '2', Expired: true },
        { Building: 'R1', Room: '2.38', Date: '30-05-2020', StartTime: '11:00', EndTime: '12:00', Duration: '1', Expired: false },
        { Building: 'R10', Room: '1.11', Date: '01-06-2020', StartTime: '08:00', EndTime: '12:00', Duration: '4', Expired: false },
        { Building: 'R5', Room: '3.05', Date: '06-06-2020', StartTime: '09:00', EndTime: '10:00', Duration: '1', Expired: false },
        { Building: 'R5', Room: '2.40', Date: '04-06-2020', StartTime: '12:00', EndTime: '14:00', Duration: '2', Expired: false },
        { Building: 'R8', Room: '2.20', Date: '07-06-2020', StartTime: '14:00', EndTime: '16:00', Duration: '2', Expired: false },
        { Building: 'R1', Room: '4.22', Date: '14-06-2020', StartTime: '16:00', EndTime: '17:00', Duration: '1', Expired: false },
        { Building: 'R10', Room: '3.16', Date: '31-05-2020', StartTime: '10:00', EndTime: '16:00', Duration: '4', Expired: false }
      ]

    }
  }
}

</script>
