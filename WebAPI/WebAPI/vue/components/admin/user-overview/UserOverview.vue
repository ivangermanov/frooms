<template>
  <v-data-table
    :headers="headers"
    :items="users"
    sort-by="Name"
    class="elevation-1"
  >
    <v-dialog v-model="dialog" max-width="500px">
      <v-card>
        <v-card-title>
          <span class="headline"> Edit the roles</span>
        </v-card-title>

        <v-card-text>
          <v-container>
            hey
          </v-container>
        </v-card-text>

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
      roles: {
        isAdmin: false,
        isUser: false
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
    editUser (roles) {
      console.log(roles)
      this.dialog = true
    },
    close () {
      this.dialog = false
    },

    save () {
      this.close()
    }
  }
}
</script>
