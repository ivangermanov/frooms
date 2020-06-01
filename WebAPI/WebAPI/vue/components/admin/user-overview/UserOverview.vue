<template>
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
    :items="users"
      :search="search"
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
              <v-radio label="User" class="mb-4" color="primary" :value="0" />
              <v-radio label="Admin" color="primary" :value="1" />
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
      <template v-slot:item.role="{ item }">
        <span>{{ formattedUserRole(item.role) }}</span>
      </template>
      <template v-slot:item.actions="{ item }">
        <v-icon
          small
          class="mr-2"
          @click="editUser(item)"
        >
          mdi-pencil
        </v-icon>
        <v-icon
          v-if="!item.isBlocked"
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
      },
      headers: [
        {
          text: 'Name',
          align: 'start',
          value: 'name'
        },
        { text: 'Email', value: 'email' },
        { text: 'Role', value: 'role' },
        { text: 'Actions', value: 'actions', sortable: false }
      ]
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
      this.selectedUserIndex = this.users.indexOf(user)
      this.selectedUserRole = user.role
      this.dialog = true
    },
    formattedUserRole (role) {
      return role === 1 ? 'Admin' : 'User'
    },
    close () {
      this.dialog = false
    },
    async save () {
      console.log(this.selectedUserRole)
      if (this.selectedUserRole !== this.users[this.selectedUserIndex].role) {
        console.log(this.selectedUserRole)
        const { data } = await AdminUserRepository.changeRole(this.users[this.selectedUserIndex].id, this.selectedUserRole)
        Object.assign(this.users[this.selectedUserIndex], data)
      }
      this.close()
    }
  }
}
</script>
