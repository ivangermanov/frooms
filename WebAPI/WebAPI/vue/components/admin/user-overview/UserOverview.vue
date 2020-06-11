<template>
  <v-container>
    <v-row justify="center">
      <v-col cols="8">
        <v-card>
          <v-card-title>
            <v-text-field
              v-model="search"
              append-icon="mdi-magnify"
              label="Search"
              single-line
              hide-details
            />
          </v-card-title>
          <v-data-table
            :headers="headers"
            :items="mungedUsers"
            :search="search"
            :items-per-page="5"
            sort-by="Name"
            class="elevation-1"
          >
            <template v-slot:top>
              <v-dialog v-model="dialog" max-width="350px">
                <v-card>
                  <v-card-title>
                    <span class="headline"> Edit the roles</span>
                  </v-card-title>
                  <v-radio-group v-model="selectedUserRole" class="ml-8" :mandatory="true">
                    <v-radio label="Admin" color="primary" :value="1" />
                    <v-radio label="User" class="mb-4" color="primary" :value="0" />
                  </v-radio-group>
                  <v-card-actions>
                    <v-spacer />
                    <v-btn color="blue darken-1" text @click="close">
                      Cancel
                    </v-btn>
                    <v-btn color="blue darken-1" text @click="save">
                      Save
                    </v-btn>
                  </v-card-actions>
                </v-card>
              </v-dialog>
            </template>
            <template v-slot:item.actions="{ item }">
              <!-- TODO: Add hover over text to icons -->
              <v-icon
                small
                class="mr-2"
                @click="editUser(item)"
              >
                mdi-pencil
              </v-icon>
              <v-icon
                v-if="!item.isBlocked && item.role === 0"
                small
                @click="blockUser(item)"
              >
                mdi-account-lock
              </v-icon>
              <v-icon
                v-if="item.isBlocked"
                small
                @click="unblockUser(item)"
              >
                mdi-account-key
              </v-icon>
            </template>
          </v-data-table>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { RepositoryFactory } from '@/api/repositoryFactory'

const AdminUserRepository = RepositoryFactory.adminUser

export default {
  props: {
    users: {
      type: Array,
      required: true
    }
  },
  data () {
    return {
      dialog: false,
      search: '',
      selectedUserIndex: Number,
      selectedUserRole: Number,
      headers: [
        {
          text: 'Name',
          align: 'start',
          value: 'name'
        },
        { text: 'Email', value: 'email' },
        { text: 'Role', value: 'sortable_role' },
        { text: 'Actions', value: 'actions', sortable: false }
      ]
    }
  },
  computed: {
    mungedUsers () {
      return this.users.map((v, i) => {
        return {
          ...v,
          sortable_role: this.formatUserRole(v.role),
          index: i
        }
      })
    }
  },
  watch: {
    dialog (val) {
      val || this.close()
    }
  },
  methods: {
    async blockUser (user) {
      if (confirm('Are you sure you want to block this user?')) {
        const { data } = await AdminUserRepository.blockUser(user.id)
        user.isBlocked = data.isBlocked
      }
    },
    async unblockUser (user) {
      if (confirm('Are you sure you want to unblock this user?')) {
        const { data } = await AdminUserRepository.unblockUser(user.id)
        user.isBlocked = data.isBlocked
      }
    },
    editUser (user) {
      this.selectedUserIndex = user.index
      console.log(this.selectedUserIndex)
      this.selectedUserRole = user.role
      this.dialog = true
    },
    formatUserRole (role) {
      return role === 1 ? 'Admin' : 'User'
    },
    close () {
      this.dialog = false
    },
    async save () {
      if (this.selectedUserRole !== this.users[this.selectedUserIndex].role) {
        const { data } = await AdminUserRepository.changeRole(this.users[this.selectedUserIndex].id, this.selectedUserRole)
        Object.assign(this.users[this.selectedUserIndex], data)
      }
      this.close()
    }
  }
}
</script>
