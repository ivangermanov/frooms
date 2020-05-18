<template>
  <v-layout column justify-center align-center>
      <v-tabs
        v-model="tab"
        background-color="primary"
        dark
      >
        <v-tab
          :key="Users"
        >
          Users
        </v-tab>
        <v-tab
          :key="Reservations"
        >
          Reservations
        </v-tab>
        <v-tab
          :key="Statistics"
        >
          Statistics
        </v-tab>
      </v-tabs>
  
      <v-tabs-items v-model="tab">
        <v-tab-item
          :key="Users"
        >
          <user-overview />
        </v-tab-item>
                <v-tab-item
            :key="Reservations"
          >
          Reservations
        </v-tab-item>
                <v-tab-item
            :key="Statistics"
          >
          Statistics
        </v-tab-item>
      </v-tabs-items>
  </v-layout>
</template>

<script lang="ts">
import UserOverview from '@/components/admin/user-overview/UserOverview.vue'
export default {
  middleware: 'admin',
  layout: 'admin',
  components: { UserOverview },
    data () {
    return {
      tab: null
      }
    }
}
</script>
