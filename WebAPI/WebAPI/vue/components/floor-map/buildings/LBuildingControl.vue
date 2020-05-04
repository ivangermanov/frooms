<template>
  <l-control :position="position">
    <div class="control">
      <v-container>
        <v-autocomplete
          :value="buildingName"
          :items="buildings"
          :dark="false"
          :light="true"
          :dense="true"
          label="Building"
          @change="updateBuildingName"
        />
      </v-container>
    </div>
  </l-control>
</template>

<script lang="ts">
import { LControl } from 'vue2-leaflet'

import Vue from 'vue'
export default Vue.extend({
  components: {
    LControl
  },
  props: {
    position: {
      type: String,
      required: true
    },
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
