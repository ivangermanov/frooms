<template>
  <v-container class="container">
    <v-layout row wrap justify-space-between>
      <v-flex xs12 md7>
        <reservations-list />
      </v-flex>
      <v-flex xs12 md4>
        <notifications-list />
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue'
import NotificationsList from '~/components/base/NotificationsList.vue'
import ReservationsList from '~/components/reservations/ReservationsList.vue'

export default Vue.extend({
  components: {
    NotificationsList, ReservationsList
  }
})
</script>
