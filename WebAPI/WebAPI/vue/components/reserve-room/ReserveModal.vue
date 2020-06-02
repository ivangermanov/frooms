<template>
  <v-container>
    <v-row>
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

          <v-responsive :height="$vuetify.breakpoint.xs ? 'auto' : '500'">
            <v-stepper-items>
              <v-stepper-content
                :step="1"
              >
                <room-filter
                  :campuses="data.campuses"
                  :initial="externalReservationDetails"
                  @update-reservation-details="updateReservationDetailsEvent"
                />
              </v-stepper-content>

              <v-stepper-content
                :step="2"
              >
                <pick-room
                  :rooms="data.rooms"
                  :selected-room="reservationDetails.room"
                  :initial-room="externalReservationDetails.room"
                  :floors="data.floors"
                  :selected-floor.sync="reservationDetails.floor"
                  :initial-floor="externalReservationDetails.floor"
                  @update-selected-room="updateSelectedRoom"
                  @fetch-rooms="fetchRooms"
                />
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

            <v-btn text @click="$emit('close');">
              Cancel
            </v-btn>
          </div>
        </v-stepper>
      </v-dialog>
    </v-row>
  </v-container>
</template>

<script>
import RoomFilter from './room-filter/RoomFilter.vue'
import PickRoom from './pick-room/PickRoom.vue'
import ConfirmReservation from './confirm-reservation/ConfirmReservation.vue'
import Loader from '~/components/base/BaseLoader.vue'

import { RepositoryFactory } from '@/api/repositoryFactory'

const CampusRepository = RepositoryFactory.campus
const RoomRepository = RepositoryFactory.room
const UserRepository = RepositoryFactory.user
const ReservationRepository = RepositoryFactory.reservation
const FloorRepository = RepositoryFactory.floor

export default {
  components: { Loader, RoomFilter, PickRoom, ConfirmReservation },
  props: {
    externalReservationDetails: {
      type: Object,
      required: false,
      default: () => ({
        campus: null,
        building: null,
        floor: '',
        room: null,
        startDate: null,
        endDate: null
      })
    }
  },
  data () {
    return {
      data: {
        campuses: [],
        rooms: [],
        floors: []
      },
      loading: true,
      dialog: false,
      currentStep: 1,
      steps: 3,
      reservationDetails: {
        campus: null,
        building: null,
        floor: null,
        room: null,
        startDate: null,
        endDate: null
      }
    }
  },
  computed: {
    roomFilterOptionsAreReady () {
      return this.reservationDetails.campus != null &&
      this.reservationDetails.building != null &&
      this.reservationDetails.startDate != null &&
      this.reservationDetails.endDate != null
    },

    reservationDetailsAreReady () {
      return this.roomFilterOptionsAreReady && (this.reservationDetails.room != null || this.currentStep === 1)
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
        this.postReservation()
        this.dialog = false
      }
    },
    previousStep () {
      if (this.currentStep > 1) {
        this.currentStep -= 1
      }
    },
    async fetchCampuses () {
      const { data } = await CampusRepository.getCampuses()
      this.data.campuses = data

      this.loading = false
      this.dialog = true
    },
    async fetchRooms () {
      if (this.roomFilterOptionsAreReady && this.reservationDetails.floor != null) {
        const { data } = await RoomRepository.getAvailableRooms(
          this.reservationDetails.campus.name,
          this.reservationDetails.building.name,
          this.reservationDetails.floor.number,
          this.reservationDetails.startDate,
          this.reservationDetails.endDate
        )
        this.data.rooms = data
        this.reservationDetails.room = null
      }
    },
    async fetchFloors () {
      // TODO: Empty floors better be filtered out
      const { data } = await FloorRepository.getFloors(this.reservationDetails.building.name)
      this.data.floors = data
      await this.fetchRooms()
    },
    async postReservation () {
      const currentUserId = this.$store.state.user.info.sub
      const currentUserName = this.$store.state.user.info.name
      const currentUserEmail = this.$store.state.user.info.email
      await UserRepository.findOrCreateUser({
        id: currentUserId,
        name: currentUserName,
        email: currentUserEmail
      })

      await ReservationRepository.postReservation(
        {
          userId: currentUserId,
          roomId: this.reservationDetails.room.id,
          startDate: this.reservationDetails.startDate,
          endDate: this.reservationDetails.endDate
        }
      )
    },
    updateReservationDetailsEvent (value) {
      this.reservationDetails.campus = value.campus
      this.reservationDetails.building = value.building
      this.reservationDetails.startDate = value.startDate
      this.reservationDetails.endDate = value.endDate
      if (this.roomFilterOptionsAreReady) {
        this.fetchFloors()
      }
    },
    updateSelectedRoom (value) {
      this.reservationDetails.room = value
    },
    padTime (time) {
      return time < 10 ? `0${time}` : `${time}`
    }
  }
}
</script>
