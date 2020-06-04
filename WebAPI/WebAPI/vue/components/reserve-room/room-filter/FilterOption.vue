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
import moment from 'moment'
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
    },
    initial: {
      type: Object,
      required: true
    }
  },
  setup (props, { emit }) {
    const dates = useReservationDates()
    const { startDate, endDate, ...rest } = dates
    if (props.initial.startDate) {
      rest.startTime.value = moment(props.initial.startDate).format('HH:mm')
    }
    if (props.initial.endDate) {
      rest.endTime.value = moment(props.initial.endDate).format('HH:mm')
    }

    const selectedCampusName = ref(props.initial.campus || '')
    const selectedBuildingName = ref(props.initial.building || '')
    const details = reactive({
      campus: null as any,
      building: null as any,
      room: null,
      startDate,
      endDate
    })

    function updateReservationDetailsEvent () {
      emit('update-reservation-details', details)
    }

    const campusNames = computed(() => props.campuses.map((campus: any) => campus.name))
    const buildingNames = computed(() => {
      if (!details.campus) {
        return []
      }
      return details.campus.buildings.map((building: any) => building.name)
    })

    watch(selectedCampusName, (name) => {
      if (!name) { return }
      details.campus = props.campuses.filter(campus => campus.name === name)[0]
      updateReservationDetailsEvent()
    })
    watch(selectedBuildingName, (name) => {
      if (!name) { return }
      details.building = details.campus.buildings.filter((building: any) => building.name === name)[0]
      updateReservationDetailsEvent()
    })

    // watch(() => props.initial.startDate, (startDate) => {
    //   if (startDate) {
    //     rest.startTime.value = moment(startDate).format('HH:mm')
    //   }
    // })
    // watch(() => props.initial.endDate, (endDate) => {
    //   if (endDate) {
    //     rest.endTime.value = moment(endDate).format('HH:mm')
    //   }
    // })

    watch(() => [details.startDate, details.endDate],
      () => {
        updateReservationDetailsEvent()
      })

    return { ...toRefs(rest as any), campusNames, buildingNames, selectedCampusName, selectedBuildingName }
  }
})
</script>
