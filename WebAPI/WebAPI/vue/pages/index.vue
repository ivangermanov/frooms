<template>
  <v-layout column justify-center align-center>
    <v-flex xs12 sm8 md6>
      <v-card>
        <v-card-title class="headline">
          Welcome to Froom
        </v-card-title>
        <v-card-text>
          <p>
            Froom is an application to book rooms. Head over to the Floor map page to select a room of your choice!
          </p>
        </v-card-text>
        <v-card-actions>
          <v-spacer />
          <v-btn color="primary" nuxt to="/floor-map">
            Continue
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script lang="ts">
import Vue from 'vue'
import { RepositoryFactory } from '@/api/repositoryFactory'
const AuthRepository = RepositoryFactory.auth

export default Vue.extend({
  created () {
    this.getUserData()
  },
  methods: {
    async getUserData () {
      const { data } = await AuthRepository.getUserInfo()
      console.log(data)
    }
  }
})
</script>
