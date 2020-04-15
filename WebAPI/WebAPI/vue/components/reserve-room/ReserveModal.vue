<template>
  <v-container>
    <v-row justify="center">
      <loader :loading="loading" />

      <v-dialog
        v-model="dialog"
        :fullscreen="$vuetify.breakpoint.xs"
        max-width="950"
        persistent
      >
        <v-stepper v-model="currentStep">
          <v-stepper-header>
            <template v-for="n in steps">
              <v-stepper-step
                :key="`${n}-step`"
                :complete="currentStep > n"
                :step="n"
                :editable="reservationDetailsAreReady"
              >
                Step {{ n }}
              </v-stepper-step>

              <v-divider
                v-if="n !== steps"
                :key="n"
              />
            </template>
          </v-stepper-header>

          <v-responsive height="500">
            <v-stepper-items>
              <v-stepper-content
                :step="1"
              >
                <room-filter :campuses="data.campuses" @update-reservation-details="updateReservationDetailsEvent" />
              </v-stepper-content>

              <v-stepper-content
                :step="2"
              >
                <pick-room :rooms="data.rooms" @update-selected-room="updateSelectedRoom" />
              </v-stepper-content>

              <v-stepper-content
                :step="3"
              >
                <confirm-reservation :reservation-details="reservationDetails" />
              </v-stepper-content>
            </v-stepper-items>
          </v-responsive>
          <div class="text-right mt-3 mb-3 mr-5">
            <v-btn
              :disabled="reservationDetailsAreReady === false"
              color="primary"
              @click="nextStep()"
            >
              {{ currentStep === 3 ? 'Finish' : 'Continue' }}
            </v-btn>

            <v-btn
              :disabled="currentStep === 1"
              color="red lighten-1"
              @click="previousStep()"
            >
              Previous
            </v-btn>

            <v-btn text to="/">
              Cancel
            </v-btn>
          </div>
        </v-stepper>
      </v-dialog>
    </v-row>
  </v-container>
</template>

<script>
import Loader from './Loader.vue'
import RoomFilter from './RoomFilter.vue'
import PickRoom from './PickRoom.vue'
import ConfirmReservation from './ConfirmReservation.vue'

import { RepositoryFactory } from '@/api/repositoryFactory'
const CampusRepository = RepositoryFactory.campus
const RoomRepository = RepositoryFactory.room

export default {

  components: { Loader, RoomFilter, PickRoom, ConfirmReservation },

  data () {
    return {
      data: {
        campuses: [],
        rooms: []
      },
      loading: true,
      dialog: false,
      currentStep: 1,
      steps: 3,
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
    reservationDetailsAreReady () {
      return this.reservationDetails.campus != null &&
      this.reservationDetails.building != null &&
      this.reservationDetails.startDate != null &&
      this.reservationDetails.endDate != null
    }
  },

  mounted () {
    this.loading = true
    this.dialog = false
    this.fetchCampuses()
  },

  methods: {
    nextStep () {
      if (this.currentStep < this.steps) {
        this.currentStep += 1
      } else {
        // Post the reservation
        this.dialog = false
        this.$router.push({
          path: '/'
        })
      }
    },

    previousStep () {
      if (this.currentStep > 1) {
        this.currentStep -= 1
      }
    },

    fetchCampuses () {
      const fetch = async () => {
        const { data } = await CampusRepository.getCampuses()
        this.data.campuses = data
      }

      fetch()

      this.loading = false
      this.dialog = true
    },

    fetchRooms () {
      const fetch = async () => {
        const { data } = await RoomRepository.getRooms(this.reservationDetails.campus.name, this.reservationDetails.building.name)
        this.data.rooms = data
      }

      fetch()
    },

    updateReservationDetailsEvent (value) {
      this.reservationDetails.campus = value.campus
      this.reservationDetails.building = value.building
      this.reservationDetails.startDate = value.startDate
      this.reservationDetails.endDate = value.endDate

      if (this.reservationDetailsAreReady) {
        this.fetchRooms()
      }
    },

    updateSelectedRoom (value) {
      this.reservationDetails.room = value
    }
  }
}
</script>
