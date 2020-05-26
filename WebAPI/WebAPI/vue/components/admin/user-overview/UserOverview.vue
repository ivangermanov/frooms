<template>
  <v-data-table
      :headers="headers"
      :items="users"
      sort-by="Name"
      class="elevation-1"
  >
    <template v-slot:item.actions="{ item }">
      <v-icon
        small
        class="mr-2"
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
      headers: [
        {
          text: 'Name',
          align: 'start',
          value: 'name',
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
      const { data } = await AdminUserRepository.blockUser(user.id);
      user.isBlocked = data.isBlocked;
    },
    async unblockUser (user) {
      const { data } = await AdminUserRepository.unblockUser(user.id);
      user.isBlocked = data.isBlocked;
    },
  }
}
</script>
