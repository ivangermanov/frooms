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
const UserRepository = RepositoryFactory.user

export default Vue.extend({
  created () {
    this.getUserInfo()
    this.getUserRoles()
  },
  methods: {
    async getUserInfo () {
      const { data } = await UserRepository.getUserInfo()
      console.log(data)
    },
    async getUserRoles () {
      const { data } = await UserRepository.getUserRoles()
      console.log(data)
    }
  }
})
</script>
