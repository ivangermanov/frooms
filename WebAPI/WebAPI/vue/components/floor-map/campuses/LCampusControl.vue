<template>
  <l-control :position="position">
    <div class="control">
      <v-container>
        <v-autocomplete
          :value="campusName"
          :items="campuses"
          :dark="false"
          :light="true"
          :dense="true"
          label="Campus"
          @change="updateCampusName"
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
