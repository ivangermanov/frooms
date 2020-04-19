<template>
  <v-row align="center" justify="center" class="text-center">
    <v-col class="col">
      <v-date-picker
        v-model="date"
        class="mt-4"
        :min="minDate"
        :max="maxDate"
      />
    </v-col>

    <v-col class="col" align-self="start">
      <!-- Selector for Campus -->
      <v-row>
        <v-col>
          <v-select
            v-model="selectedCampusName"
            :items="campusNames"
            menu-props="auto"
            label="Select a campus"
            hide-details
            prepend-icon="mdi-map-marker"
            single-line
          />
        </v-col>
      </v-row>

      <!-- Selector for Building -->
      <v-row>
        <v-col>
          <v-select
            v-model="selectedBuildingName"
            :items="buildingNames"
            menu-props="auto"
            label="Select a building"
            hide-details
            prepend-icon="mdi-home"
            single-line
          />
        </v-col>
      </v-row>

      <!-- Time Picker for Start Time -->
      <v-row>
        <v-col>
          <v-dialog
            ref="dialogStartTime"
            v-model="modalStartTime"
            :return-value.sync="startTime"
            width="290px"
          >
            <template v-slot:activator="{ on }">
              <v-text-field
                v-model="startTime"
                label="Pick a start time"
                prepend-icon="mdi-clock-outline"
                readonly
                v-on="on"
              />
            </template>
            <v-time-picker
              v-if="modalStartTime"
              v-model="startTime"
              format="24hr"
              full-width
            >
              <v-spacer />
              <v-btn text color="primary" @click="modalStartTime = false">
                Cancel
              </v-btn>
              <v-btn text color="primary" @click="$refs.dialogStartTime.save(startTime)">
                OK
              </v-btn>
            </v-time-picker>
          </v-dialog>
        </v-col>
      </v-row>

      <!-- Time Picker for End Time -->
      <v-row>
        <v-col>
          <v-dialog
            ref="dialogEndTime"
            v-model="modalEndTime"
            :return-value.sync="endTime"
            width="290px"
          >
            <template v-slot:activator="{ on }">
              <v-text-field
                v-model="endTime"
                label="Pick an end time"
                prepend-icon="mdi-clock-outline"
                readonly
                v-on="on"
              />
            </template>
            <v-time-picker
              v-if="modalEndTime"
              v-model="endTime"
              format="24hr"
              full-width
            >
              <v-spacer />
              <v-btn text color="primary" @click="modalEndTime = false">
                Cancel
              </v-btn>
              <v-btn text color="primary" @click="$refs.dialogEndTime.save(endTime)">
                OK
              </v-btn>
            </v-time-picker>
          </v-dialog>
        </v-col>
      </v-row>
    </v-col>
  </v-row>
</template>

<script>
import moment from 'moment'

export default {
  props: {
    campuses: {
      type: Array,
      required: true,
      default () {
        return []
      }
    }
  },

  data: () => ({
    date: moment().format('YYYY-MM-DD'),
    startTime: null,
    endTime: null,
    modalStartTime: false,
    modalEndTime: false,
    selectedCampusName: '',
    selectedBuildingName: '',
    reservationDetails: {
      campus: null,
      building: null,
      room: null,
      startDate: null,
      endDate: null
    }
  }),

  computed: {
    minDate () {
      return moment().format('YYYY-MM-DD')
    },

    maxDate () {
      // TODO: calculate based on semester
      return moment().add(3, 'M').format('YYYY-MM-DD')
    },

    computedStartDate () {
      if (this.startTime == null) {
        return null
      }

      return `${this.date} ${this.startTime}:00`
    },

    computedEndDate () {
      if (this.endTime == null) {
        return null
      }

      return `${this.date} ${this.endTime}:00`
    },

    campusNames () {
      return this.campuses.map((campus) => { return campus.name })
    },

    buildingNames () {
      if (this.reservationDetails.campus === null) {
        return []
      }

      return this.reservationDetails.campus.buildings.map((building) => { return building.name })
    }
  },

  watch: {
    selectedCampusName () {
      this.reservationDetails.campus = this.campuses.filter((campus) => { return campus.name === this.selectedCampusName })[0]
      this.updateReservationDetailsEvent()
    },

    selectedBuildingName () {
      this.reservationDetails.building = this.reservationDetails.campus.buildings.filter((building) => { return building.name === this.selectedBuildingName })[0]
      this.updateReservationDetailsEvent()
    },

    startTime () {
      this.reservationDetails.startDate = this.computedStartDate
      this.updateReservationDetailsEvent()
    },

    endTime () {
      this.reservationDetails.endDate = this.computedEndDate
      this.updateReservationDetailsEvent()
    }
  },

  methods: {
    updateReservationDetailsEvent () {
      this.$emit('update-reservation-details', this.reservationDetails)
    }
  }
}
</script>
