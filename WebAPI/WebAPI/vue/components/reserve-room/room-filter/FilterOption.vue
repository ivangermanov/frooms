<template>
  <v-row>
    <v-col class="col">
      <base-date-picker :date.sync="date" />
    </v-col>

    <v-col class="col">
      <v-row>
        <v-col>
          <base-drop-down-selector
            :items="campusNames"
            :selection.sync="selectedCampusName"
            label="Select a campus"
            icon="mdi-map-marker"
          />
        </v-col>
      </v-row>

      <v-row>
        <v-col>
          <base-drop-down-selector
            :items="buildingNames"
            :selection.sync="selectedBuildingName"
            label="Select a building"
            icon="mdi-home"
          />
        </v-col>
      </v-row>

      <v-row>
        <v-col>
          <base-time-picker
            :time.sync="startTime"
            label="Pick a start time"
          />
        </v-col>
      </v-row>

      <v-row>
        <v-col>
          <base-time-picker
            :time.sync="endTime"
            label="Pick a end time"
            :rules="[rules.beforeStart, rules.minDuration, rules.maxDuration]"
          />
        </v-col>
      </v-row>
    </v-col>
  </v-row>
</template>

<script>
import moment from 'moment'
import BaseDatePicker from './BaseDatePicker'
import BaseDropDownSelector from './BaseDropDownSelector'
import BaseTimePicker from './BaseTimePicker'

export default {
  components: { BaseDatePicker, BaseDropDownSelector, BaseTimePicker },

  props: {
    campuses: {
      type: Array,
      required: true,
      default () {
        return []
      }
    }
  },

  data () {
    return {
      date: moment().format('YYYY-MM-DD'),
      startTime: '',
      endTime: '',
      selectedCampusName: '',
      selectedBuildingName: '',
      minDuration: 900,
      maxDuration: 10800,
      rules: {
        beforeStart: true || 'End time should be after start',
        minDuration: true || 'Duration is too short',
        maxDuration: true || 'Duration is too long'
      },
      reservationDetails: {
        campus: null,
        building: null,
        room: null,
        startDate: null,
        endDate: null
      }
    }
  },

  computed: {
    computedStartDate () {
      if (this.startTime === '') {
        return null
      }

      return moment(`${this.date} ${this.startTime}`)
    },

    computedEndDate () {
      if (this.endTime === '') {
        return null
      }

      return moment(`${this.date} ${this.endTime}`)
    },

    campusNames () {
      return this.campuses.map((campus) => { return campus.name })
    },

    buildingNames () {
      if (this.reservationDetails.campus === null) {
        return []
      }

      return this.reservationDetails.campus.buildings.map((building) => { return building.name })
    },

    checkBeforeStart () {
      if (this.computedStartDate != null && this.computedEndDate != null) {
        return moment(this.computedStartDate).isBefore(this.computedEndDate)
      }

      return true
    },

    checkMinimalDuration () {
      if (this.computedStartDate != null && this.computedEndDate != null) {
        return Math.abs(this.computedEndDate.diff(this.computedStartDate, 'seconds')) >= this.minDuration
      }

      return true
    },

    checkMaximualDuration () {
      if (this.computedStartDate != null && this.computedEndDate != null) {
        return Math.abs(this.computedEndDate.diff(this.computedStartDate, 'seconds')) <= this.maxDuration
      }

      return true
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
      if (this.checkBeforeStart && this.checkMinimalDuration && this.checkMaximualDuration) {
        this.reservationDetails.startDate = this.computedStartDate
      } else {
        this.reservationDetails.startDate = null
      }

      this.updateReservationDetailsEvent()
      this.changeDurationRule()
    },

    endTime () {
      if (this.checkBeforeStart && this.checkMinimalDuration && this.checkMaximualDuration) {
        this.reservationDetails.endDate = this.computedEndDate
      } else {
        this.reservationDetails.endDate = null
      }

      this.updateReservationDetailsEvent()
      this.changeDurationRule()
    }
  },

  methods: {
    updateReservationDetailsEvent () {
      this.$emit('update-reservation-details', this.reservationDetails)
    },

    changeDurationRule () {
      this.rules.beforeStart = this.checkBeforeStart || 'End time should be after start'
      this.rules.minDuration = this.checkMinimalDuration || 'Duration is too short'
      this.rules.maxDuration = this.checkMaximualDuration || 'Duration is too long'
    }
  }
}
</script>
