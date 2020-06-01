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

<script lang="ts">
import { ref, toRefs, reactive, watch, computed, defineComponent, PropType } from '@vue/composition-api'
import BaseTimePicker from '@/components/base/BaseTimePicker.vue'
import BaseDatePicker from '@/components/base/BaseDatePicker.vue'
import BaseDropDownSelector from '@/components/base/BaseDropdownSelector.vue'
import useReservationDates from '@/composition/use-reservation-dates'

export default defineComponent({
  components: { BaseDatePicker, BaseDropDownSelector, BaseTimePicker },

  props: {
    campuses: {
      type: Array as PropType<Array<any>>,
      required: true,
      default: () => []
    }
  },
  setup ({ campuses }, { emit }) {
    const dates = useReservationDates()
    const { startDate, endDate, ...rest } = dates
    const selectedCampusName = ref('')
    const selectedBuildingName = ref('')
    const reservationDetails = reactive({
      campus: null as any,
      building: null as any,
      room: null,
      startDate,
      endDate
    })

    function updateReservationDetailsEvent () {
      emit('update-reservation-details', reservationDetails)
    }

    const campusNames = computed(() => campuses.map((campus: any) => campus.name))
    const buildingNames = computed(() => {
      if (reservationDetails.campus === null) {
        return []
      }
      return reservationDetails.campus.buildings.map((building: any) => building.name)
    })

    watch(selectedCampusName, (name) => {
      if (!name) { return }
      reservationDetails.campus = campuses.filter(campus => campus.name === name)[0]
      updateReservationDetailsEvent()
    })
    watch(selectedBuildingName, (name) => {
      if (!name) { return }
      reservationDetails.building = reservationDetails.campus.buildings.filter((building: any) => building.name === name)[0]
      updateReservationDetailsEvent()
    })

    watch(() => [reservationDetails.startDate, reservationDetails.endDate],
      () => { updateReservationDetailsEvent() })

    return { ...toRefs(rest as any), reservationDetails, campusNames, buildingNames, selectedCampusName, selectedBuildingName }
  }
})
</script>
