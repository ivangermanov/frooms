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
        small
      >
        mdi-delete
      </v-icon>
    </template>
  </v-data-table>
</template>

<script>
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
  }
}
</script>
