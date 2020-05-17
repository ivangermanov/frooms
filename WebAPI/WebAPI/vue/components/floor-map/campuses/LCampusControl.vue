<template>
  <div class="control">
    <v-container>
      <v-autocomplete
        prepend-icon="mdi-school"
        :value="campusName"
        :items="campuses"
        :dark="false"
        :light="true"
        :dense="true"
        label="Campus"
        hide-details="auto"
        @change="updateCampusName"
      />
    </v-container>
  </div>
</template>

<script lang="ts">

import Vue from 'vue'
export default Vue.extend({
  props: {
    campuses: {
      type: Array,
      default: [] as String[]
    },
    campusName: {
      type: String,
      default: ''
    }
  },
  methods: {
    updateCampusName (value: string) {
      this.$emit('update:campusName', value)
    }
  }
})
</script>
