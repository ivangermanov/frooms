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
        <user-overview />
      </v-tab-item>
      <v-tab-item>
        Reservations
      </v-tab-item>
      <v-tab-item>
        <v-card class="d-inline-block mx-auto">
          <v-card-title>
            Statistics
          </v-card-title>
          <v-container>
            <v-row justify="space-between">
              <v-col cols="auto">
                <base-chart />
              </v-col>
            </v-row>
          </v-container>
        </v-card>
      </v-tab-item>
    </v-tabs-items>
  </v-layout>
</template>

<script lang="ts">
import Vue from 'vue'
import UserOverview from '@/components/admin/user-overview/UserOverview.vue'
import BaseChart from '@/components/charts/BaseChart.vue'

export default Vue.extend({
  layout: 'admin',
  components: { UserOverview, BaseChart },
  data () {
    return {
      tab: null
    }
  }
})
</script>
