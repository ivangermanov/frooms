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
      <v-row>
        <v-col>
          <v-select
            :items="buildingNames"
            menu-props="auto"
            label="Select a building"
            hide-details
            prepend-icon="mdi-map-marker"
            single-line
          />
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <v-dialog
            ref="dialog"
            v-model="modal"
            :return-value.sync="time"
            width="290px"
          >
            <template v-slot:activator="{ on }">
              <v-text-field
                v-model="time"
                label="Pick a time"
                prepend-icon="mdi-clock-outline"
                readonly
                v-on="on"
              />
            </template>
            <v-time-picker
              v-if="modal"
              v-model="time"
              format="24hr"
              full-width
            >
              <v-spacer />
              <v-btn text color="primary" @click="modal = false">
                Cancel
              </v-btn>
              <v-btn text color="primary" @click="$refs.dialog.save(time)">
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
    buildings: {
      type: Array,
      required: true,
      default () {
        return []
      }
    }
  },

  data: () => ({
    date: moment().format('YYYY-MM-DD'),
    time: null,
    menu: false,
    modal: false
  }),

  computed: {
    minDate () {
      return moment().format('YYYY-MM-DD')
    },

    maxDate () {
      // TODO: calculate based on semester
      return moment().add(3, 'M').format('YYYY-MM-DD')
    },

    buildingNames () {
      return this.buildings.map((building) => { return building.name })
    }
  }
}
</script>
