<template>
  <v-layout column justify-center align-center>
    <!-- You can place your components here to test them like the UserOverview component below, I will move to accordingly -->
    <user-overview />
  </v-layout>
</template>

<script lang="ts">
import UserOverview from '@/components/admin/user-overview/UserOverview.vue'
export default {
  middleware: 'admin',
  layout: 'admin',
  components: { UserOverview }
}
</script>
