<template>
  <div id="app">
    <v-app id="inspire">
      <div>
        <v-data-table
          :headers="reservationsHeaders"
          :items="reservations"
        >
          <template v-slot:item.user.email="props">
            <v-edit-dialog
              :return-value.sync="props.item.user.email"
              @save="save"
              @cancel="cancel"
              @open="open"
              @close="close"
            >
              {{ props.item.user.email }}
              <template v-slot:input>
                <v-autocomplete
                  v-model="props.item.user.email"
                  label="Edit"
                  single-line
                  persistent-hint
                  :items="userEmails"
                />
              </template>
              <template v-slot:item.actions="{ item }">
                <v-icon
                  small
                  class="mr-2"
                  @click="deleteReservation(item)"
                >
                  mdi-delete
                </v-icon>
              </template>
            </v-edit-dialog>
          </template>
        </v-data-table>

        <v-snackbar v-model="snack" :timeout="3000" :color="snackColor">
          {{ snackText }}
          <v-btn text @click="snack = false">
            Close
          </v-btn>
        </v-snackbar>
      </div>
    </v-app>
  </div>
</template>

<script>
import { RepositoryFactory } from '@/api/repositoryFactory'

const AdminReservationRepository = RepositoryFactory.adminReservation
const AdminUserRepository = RepositoryFactory.adminUser

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
      users: [],
      reservations: [],
      userEmails: [],
      snack: false,
      snackColor: '',
      snackText: '',
      max25chars: v => v.length <= 25 || 'Input too long!',
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
        { text: 'Actions', value: 'actions', sortable: false }

      ]
    }
  },
  mounted () {
    this.reservations = this.inputReservations
    this.users = this.inputUsers
    this.userEmails = this.users.map((user) => {
      return user.email
    })
    this.userEmails = [...new Set(this.userEmails)]
  },
  methods: {
    checkUsersData () {
      let toSend = false
      const localReservations = this.reservations
      localReservations.forEach((part, index, self) => {
        this.users.forEach((user, uIndex) => {
          // check if the email makes sense
          toSend = false
          if (this.users[uIndex].email === localReservations[index].user.email) {
            // check if the id is correct
            if (this.users[uIndex].id === localReservations[index].user.id) {
              // if the data makes sense don't rever to old values
            } else {
              toSend = true
              this.reservations[index].user = Object.assign({}, this.users[uIndex])
            }
          }

          if (toSend) {
            const currentReservation = this.reservations[index]
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
        })
      })
      this.reservations = localReservations
    },
    save () {
      // check the users data if it makes sense
      this.checkUsersData()

      this.snack = true
      this.snackColor = 'success'
      this.snackText = 'Data saved'
    },
    cancel () {
      this.snack = true
      this.snackColor = 'error'
      this.snackText = 'Canceled'
    },
    open () {
      this.snack = true
      this.snackColor = 'info'
      this.snackText = 'Dialog opened'
    },
    close () {
      console.log('Dialog closed')
    },

    deleteReservation (reservation) {
      const index = this.reservations.indexOf(reservation)
      const choice = confirm('Are you sure you want to delete this item?')

      if (choice === true) {
        AdminReservationRepository.deleteReservation(reservation.id)
        this.reservations.splice(index, 1)
      }
    },

    editReservation (reservationToEdit) {
      // updateReservation
      console.log(reservationToEdit)
      this.dialog = true
    }

  }
}
</script>
