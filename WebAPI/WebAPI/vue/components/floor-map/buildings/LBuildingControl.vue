<template>
  <div class="control">
    <v-container>
      <v-autocomplete
        prepend-icon="mdi-domain"
        :value="buildingName"
        :items="buildings"
        :dark="false"
        :light="true"
        :dense="true"
        label="Building"
        hide-details="auto"
        @change="updateBuildingName"
      />
    </v-container>
  </div>
</template>

<script lang="ts">

import Vue from 'vue'
export default Vue.extend({
  props: {
    buildings: {
      type: Array,
      default: [] as String[]
    },
    buildingName: {
      type: String,
      default: ''
    }
  },
  methods: {
    updateBuildingName (value: string) {
      this.$emit('update:buildingName', value)
    }
  }
})
</script>
