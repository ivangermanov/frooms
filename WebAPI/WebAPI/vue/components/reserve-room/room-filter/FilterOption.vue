<template>
  <v-row>
    <v-col class="col">
      <base-date-picker :date.sync="date" :min="minDate" :max="maxDate" />
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
            label="Pick a start time"
            icon="mdi-clock-time-four"
            :time.sync="startTime"
            :min="minStart"
            :max="maxStart"
          />
        </v-col>
      </v-row>

      <v-row>
        <v-col>
          <base-time-picker
            label="Pick an end time"
            icon="mdi-clock-time-nine"
            :time.sync="endTime"
            :min="minEnd"
            :max="maxEnd"
          />
        </v-col>
      </v-row>
    </v-col>
  </v-row>
</template>

<script>
import { toRefs, reactive } from '@vue/composition-api'
import BaseTimePicker from '@/components/base/BaseTimePicker.vue'
import BaseDatePicker from '@/components/base/BaseDatePicker.vue'
import BaseDropDownSelector from '@/components/base/BaseDropdownSelector.vue'
import useReservationDates from '@/composition/use-reservation-dates'

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
      selectedCampusName: '',
      selectedBuildingName: ''
    }
  },
  setup () {
    const dates = useReservationDates()
    const { startDate, endDate, ...rest } = toRefs(dates)
    const reservationDetails = reactive({
      campus: null,
      building: null,
      room: null,
      startDate,
      endDate
    })

    return { reservationDetails, ...toRefs(rest) }
  },
  computed: {
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
    }
  },

  methods: {
    updateReservationDetailsEvent () {
      this.$emit('update-reservation-details', this.reservationDetails)
    }
  }
}
</script>
