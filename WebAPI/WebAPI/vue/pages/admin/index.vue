<template>
  <v-layout column justify-center align-center>
      <v-tabs
        v-model="tab"
        background-color="primary"
        dark
      >
        <v-tab>
          Users
        </v-tab>
        <v-tab>
          Reservations
        </v-tab>
        <v-tab>
          Statistics
        </v-tab>
      </v-tabs>
  
      <v-tabs-items v-model="tab">
        <v-tab-item>
          <user-overview :users="users"/>
        </v-tab-item>
        <v-tab-item>
          Reservations
        </v-tab-item>
        <v-tab-item>
          Statistics
        </v-tab-item>
      </v-tabs-items>
  </v-layout>
</template>

<script lang="ts">

import axios from 'axios'
import UserOverview from '@/components/admin/user-overview/UserOverview.vue'

export default {
  middleware: 'admin',
  layout: 'admin',
  components: { UserOverview },
  data () {
    return {
      tab: null,
      users: []
    }
  },
  beforeMount () {
    axios.get('api/admin/users')
      .then(r => {
        this.users = r.data;
        console.log(this.users);
      });
  }
}
</script>
