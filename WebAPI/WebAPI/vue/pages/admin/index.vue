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
        <user-overview :users="users" />
      </v-tab-item>
      <v-tab-item>
        <reservations-overview />
      </v-tab-item>
      <v-tab-item>
        <v-card class="d-inline-block mx-auto">
          <chart-viewer />
        </v-card>
      </v-tab-item>
    </v-tabs-items>
  </v-layout>
</template>

<script lang="ts">
import Vue from 'vue'
import UserOverview from '@/components/admin/user-overview/UserOverview.vue'
import ReservationsOverview from '@/components/admin/reservations-overview/ReservationsOverview.vue'
import ChartViewer from '@/components/charts/ChartViewer.vue'
import { RepositoryFactory } from '@/api/repositoryFactory'

const AdminUserRepository = RepositoryFactory.adminUser
export default Vue.extend({
  layout: 'admin',
  components: { UserOverview, ChartViewer, ReservationsOverview },
  data () {
    return {
      tab: null,
      users: []
    }
  },
  beforeMount () {
    this.getUsers()
  },
  methods: {
    async getUsers () {
      const { data } = await AdminUserRepository.getUsers()
      this.users = data
    }
  }
})
</script>
