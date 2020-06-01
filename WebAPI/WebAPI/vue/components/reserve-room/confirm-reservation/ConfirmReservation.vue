<template>
  <v-card>
    <v-card-title class="headline">
      Confirm Reservation
    </v-card-title>
    <v-card-text>
      <v-simple-table>
        <template v-slot:default>
          <tbody>
            <tr v-for="item in reservationDetailsItems" :key="item.name">
              <td>{{ item.name }}</td>
              <td>{{ item.value }}</td>
            </tr>
          </tbody>
        </template>
      </v-simple-table>
    </v-card-text>
  </v-card>
</template></v-card-text>
  </v-card>
</template>

<script>
import moment from 'moment'
export default {
  components: { },

  props: {
    reservationDetails: {
      type: Object,
      required: true,
      default () {
        return null
      }
    }
  },

  computed: {
    reservationDetailsItems () {
      return [
        { name: 'Name', value: this.$store.state.user.info.name != undefined ? this.$store.state.user.info.name : '' },
        { name: 'Campus', value: this.reservationDetails.campus != null ? this.reservationDetails.campus.name : '' },
        { name: 'Building', value: this.reservationDetails.building != null ? this.reservationDetails.building.name : '' },
        { name: 'Floor', value: this.reservationDetails.room != null ? this.reservationDetails.room.floorNumber : '' },
        { name: 'Room', value: this.reservationDetails.room != null ? this.reservationDetails.room.number : '' },
        { name: 'Start Date', value: this.reservationDetails.startDate != null ? moment(this.reservationDetails.startDate).format('YYYY-MM-DD HH:mm') : '' },
        { name: 'End Date', value: this.reservationDetails.endDate != null ? moment(this.reservationDetails.endDate).format('YYYY-MM-DD HH:mm') : '' }
      ]
    }
  }
}
</script>
