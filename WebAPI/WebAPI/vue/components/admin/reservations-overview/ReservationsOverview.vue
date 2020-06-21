<template>
  <div>
    <v-card-title>
      <span class="headline">Reservations</span>
      <v-spacer />
      <v-text-field
        v-model="search"
        append-icon="mdi-magnify"
        label="Search for a reservation!"
        single-line
        hide-details
      />
    </v-card-title>
    <v-data-table
      v-if="renderTable"
      :headers="reservationsHeaders"
      :items="reservations"
      :search="search"
    >
      <template v-slot:top>
        <v-dialog v-model="dialog" max-width="700px">
          <v-form
            ref="form"
            v-model="valid"
          >
            <v-card>
              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col cols="12" sm="6" md="4">
                      <v-text-field
                        v-model="currentReservationBuilding"
                        label="Building"
                        disabled
                      />
                    </v-col>

                    <v-col cols="12" sm="6" md="4">
                      <v-autocomplete
                        v-model="currentRoomNumber"
                        :items="allRoomsForBuilding"
                        label="Room"
                      />
                    </v-col>

                    <v-col cols="12">
                      <v-autocomplete
                        v-model="currentUserEmail"
                        :items="userEmails"
                        label="Email"
                      />
                    </v-col>
                    <v-col cols="6">
                      <v-menu
                        ref="menuStartTime"
                        v-model="startTimePicker"
                        :close-on-content-click="false"
                        :nudge-right="40"
                        :return-value.sync="currentReservationStartTime"
                        transition="scale-transition"
                        offset-y
                        max-width="290px"
                        min-width="290px"
                      >
                        <template v-slot:activator="{ on, attrs }">
                          <v-text-field
                            v-model="currentReservationStartTime"
                            label="Start Time"
                            readonly
                            v-bind="attrs"
                            :rules="dateAndTimeRules"
                            v-on="on"
                          />
                        </template>
                        <v-time-picker
                          v-if="startTimePicker"
                          v-model="currentReservationStartTime"
                          full-width
                          @click:minute="$refs.menuStartTime.save(currentReservationStartTime)"
                        />
                      </v-menu>
                    </v-col>

                    <v-col cols="6">
                      <v-menu
                        ref="menuStartDate"
                        v-model="startDatePicker"
                        :close-on-content-click="false"
                        :return-value.sync="currentReservationStartDate"
                        transition="scale-transition"
                        offset-y
                        min-width="290px"
                      >
                        <template v-slot:activator="{ on, attrs }">
                          <v-text-field
                            v-model="currentReservationStartDate"
                            label="Starting Date Time"
                            readonly
                            :rules="dateAndTimeRules"
                            v-bind="attrs"
                            v-on="on"
                          />
                        </template>
                        <v-date-picker
                          v-model="currentReservationStartDate"
                          no-title
                          scrollable
                        >
                          <v-spacer />
                          <v-btn text color="primary" @click="startDatePicker = false">
                            Cancel
                          </v-btn>
                          <v-btn text color="primary" @click="$refs.menuStartDate.save(currentReservationStartDate)">
                            OK
                          </v-btn>
                        </v-date-picker>
                      </v-menu>
                    </v-col>
                    <v-col cols="6">
                      <v-menu
                        ref="menuReservationEndTime"
                        v-model="endTimePicker"
                        :close-on-content-click="false"
                        :nudge-right="40"
                        :return-value.sync="currentReservationEndTime"
                        transition="scale-transition"
                        offset-y
                        max-width="290px"
                        min-width="290px"
                      >
                        <template v-slot:activator="{ on, attrs }">
                          <v-text-field
                            v-model="currentReservationEndTime"
                            label="End Time"
                            readonly
                            :rules="dateAndTimeRules"
                            v-bind="attrs"
                            v-on="on"
                          />
                        </template>
                        <v-time-picker
                          v-if="endTimePicker"
                          v-model="currentReservationEndTime"
                          full-width
                          @click:minute="$refs.menuReservationEndTime.save(currentReservationEndTime)"
                        />
                      </v-menu>
                    </v-col>
                    <v-col cols="6">
                      <v-menu
                        ref="menuReservationEndDate"
                        v-model="endDatePicker"
                        :close-on-content-click="false"
                        :return-value.sync="currentReservationEndDate"
                        transition="scale-transition"
                        offset-y
                        min-width="290px"
                      >
                        <template v-slot:activator="{ on, attrs }">
                          <v-text-field
                            v-model="currentReservationEndDate"
                            label="End Date Time"
                            readonly
                            :rules="dateAndTimeRules"
                            v-bind="attrs"
                            v-on="on"
                          />
                        </template>
                        <v-date-picker
                          v-model="currentReservationEndDate"
                          no-title
                          scrollable
                        >
                          <v-spacer />
                          <v-btn text color="primary" @click="endDatePicker = false">
                            Cancel
                          </v-btn>
                          <v-btn text color="primary" @click="$refs.menuReservationEndDate.save(currentReservationEndDate)">
                            OK
                          </v-btn>
                        </v-date-picker>
                      </v-menu>
                    </v-col>
                  </v-row>
                </v-container>
              </v-card-text>
              <v-card-actions>
                <v-spacer />
                <v-btn color="blue darken-1" text @click="close()">
                  Close
                </v-btn>
                <v-btn :disabled="!valid" color="blue darken-1" text @click="save()">
                  Save
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-form>
        </v-dialog>
      </template>

      <template v-slot:item.expired="{ item }">
        <v-icon
          v-if="item.expired"
          small
          class="ml-4"
        >
          mdi-checkbox-marked
        </v-icon>
        <v-icon
          v-else
          small
          class="ml-4"
        >
          mdi-close-box
        </v-icon>
      </template>
      <template v-slot:item.isCancelled="{ item }">
        <v-icon
          v-if="item.isCancelled"
          small
          class="ml-4"
        >
          mdi-checkbox-marked
        </v-icon>
        <v-icon
          v-else
          small
          class="ml-4"
        >
          mdi-close-box
        </v-icon>
      </template>
      <template v-slot:item.actions="{ item }">
        <v-icon
          v-if="!item.isCancelled"
          small
          class="mr-2"
          @click="deleteReservation(item)"
        >
          mdi-delete
        </v-icon>
        <v-icon
          small
          class="mr-2"
          @click="editReservation(item)"
        >
          mdi-pencil
        </v-icon>
      </template>
    </v-data-table>
  </div>
</template>

<script>
import moment from 'moment'
import { RepositoryFactory } from '@/api/repositoryFactory'

const AdminReservationRepository = RepositoryFactory.adminReservation
const AdminRoomRepository = RepositoryFactory.roomAdmin

export default {
  props: {
    inputReservations: {
      type: Array,
      required: true
    },
    inputUsers: {
      type: Array,
      required: true
    }
  },
  data () {
    return {
      valid: true,
      dateAndTimeRules: [
        (element) => {
          const endDate = moment.utc(this.currentReservationEndDate + ' ' + this.currentReservationEndTime, 'YYYY-MM-DD  HH:mm')
          const startDate = moment.utc(this.currentReservationStartDate + ' ' + this.currentReservationStartTime, 'YYYY-MM-DD  HH:mm')
          const isafter = endDate.isAfter(startDate)

          return isafter
        }
      ],
      renderTable: true,
      currentReservationEndDate: '',
      currentReservationEndTime: '',
      currentReservationStartDate: '',
      currentReservationStartTime: '',
      currentUserEmail: '',
      currentRoomNumber: 0,
      currentReservationBuilding: null,
      allRoomsForBuilding: [],
      allPossibleBuildings: [],
      selectedReservation: null,
      startDatePicker: false,
      endDatePicker: false,
      startTimePicker: false,
      endTimePicker: false,
      start: null,
      end: null,
      roomsPerBuilding: [],
      listOfRooms: [],
      users: [],
      reservations: [],
      userEmails: [],
      dialog: false,
      search: '',
      reservationsHeaders: [

        { text: 'User Email', value: 'user.email' },
        { text: 'User', value: 'user.name' },
        { text: 'Building', value: 'room.buildingName' },
        { text: 'Room', value: 'room.number' },
        { text: 'Start Date', value: 'startingDate' },
        { text: 'End Date', value: 'endingDate' },
        { text: 'Start Time', value: 'startingTime' },
        { text: 'End Time', value: 'endingTime' },
        { text: 'Expired', value: 'expired' },
        { text: 'Cancelled', value: 'isCancelled' },
        { text: 'Actions', value: 'actions', sortable: false }

      ]
    }
  },

  mounted () {
    AdminRoomRepository.getAllRooms().then((response) => {
      const { data } = response
      this.roomsPerBuilding = data
      this.listOfRooms = this.roomsPerBuilding.map((room) => {
        return room.buildingName + ' ' + room.campusName + ' ' + room.number
      })
      const temp = []
      this.roomsPerBuilding.forEach((elem) => {
        temp.push(elem.number)
      })
      this.allRoomsForBuilding = temp
    })
    this.reservations = this.inputReservations
    this.users = this.inputUsers
    this.userEmails = this.users.map((user) => {
      return user.email
    })
    this.userEmails = [...new Set(this.userEmails)]
  },
  methods: {
    save () {
      let sendData = false
      if (this.valid) {
        this.selectedReservation.user.email = this.currentUserEmail
        this.reservations.forEach((reservation, rIndex, self) => {
          if (reservation.id === this.selectedReservation.id && sendData === false) {
            this.reservations[rIndex].startingTime = moment(this.currentReservationStartTime, 'hh:mm').format('hh:mm:ss')
            this.reservations[rIndex].startingDate = moment(this.currentReservationStartDate, 'YYYY-MM-DD').format('DD/MM/YYYY')
            this.reservations[rIndex].endingDate = moment(this.currentReservationEndDate, 'YYYY-MM-DD').format('DD/MM/YYYY')
            this.reservations[rIndex].endingTime = moment(this.currentReservationEndTime, 'hh:mm').format('hh:mm:ss')
            this.reservations[rIndex].endDate = this.currentReservationEndDate + 'T' + this.currentReservationEndTime
            this.reservations[rIndex].startDate = this.currentReservationStartDate + 'T' + this.currentReservationStartTime
            this.users.forEach((user, uIndex, self) => {
              if (this.users[uIndex].email === this.selectedReservation.user.email) {
                if (this.users[uIndex].id === this.selectedReservation.user.id) {
                } else {
                  sendData = true
                  this.reservations[rIndex].user = Object.assign({}, this.users[uIndex])
                }
              }
            })

            this.roomsPerBuilding.forEach((room) => {
              if (room.number === this.currentRoomNumber) {
                sendData = true
                this.reservations[rIndex].room = Object.assign({}, room)
              }
            })
            if (sendData) {
              const currentReservation = this.reservations[rIndex]
              AdminReservationRepository.updateReservation(
                {
                  id: currentReservation.id,
                  userId: currentReservation.user.id,
                  roomId: currentReservation.room.id,
                  startDate: currentReservation.startDate,
                  endDate: currentReservation.endDate
                }
              )
            }
          }
        })

        this.dialog = false
      }
    },
    forceRender () {
      this.renderTable = false

      this.$nextTick(() => {
        this.renderTable = true
      })
    },
    close () {
      this.dialog = false
    },

    deleteReservation (reservation) {
      const index = this.reservations.indexOf(reservation)
      const choice = confirm('Are you sure you want to delete this item?')

      if (choice === true) {
        AdminReservationRepository.deleteReservation(reservation.id)
        this.reservations[index].isCancelled = true
      }
    },

    editReservation (reservationToEdit) {
      this.currentReservationEndDate = moment(reservationToEdit.endingDate, 'DD-MM-YYYY').format('YYYY-MM-DD')
      this.currentReservationEndTime = reservationToEdit.endingTime
      this.currentReservationStartDate = moment(reservationToEdit.startingDate, 'DD-MM-YYYY').format('YYYY-MM-DD')
      this.currentReservationStartTime = reservationToEdit.startingTime
      this.selectedReservation = reservationToEdit
      this.currentReservationBuilding = reservationToEdit.room.buildingName
      this.currentRoomNumber = this.selectedReservation.room.number
      this.currentUserEmail = this.selectedReservation.user.email
      this.dialog = true
    }

  }
}
</script>
