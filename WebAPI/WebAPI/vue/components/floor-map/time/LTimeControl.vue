<template>
  <div class="control">
    <v-container>
      <v-menu
        ref="menu"
        v-model="menu"
        :close-on-content-click="false"
        :return-value.sync="time"
        transition="scale-transition"
        offset-y
      >
        <template v-slot:activator="{ on }">
          <v-text-field
            v-model="time"
            :label="label"
            :dark="false"
            :light="true"
            :dense="true"
            :prepend-icon="icon"
            readonly
            hide-details="auto"
            v-on="on"
          />
        </template>
        <v-time-picker v-model="time" @click:minute="$refs.menu.save(time)" />
      </v-menu>
    </v-container>
  </div>
</template>

<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
  props: {
    label: { type: String, default: 'Time' },
    icon: { type: String, default: 'mdi-clock' }
  },
  data () {
    return {
      time: null,
      menu: false
    }
  },
  methods: {
    // updateBuildingName (value: string) {
    //   this.$emit('update:buildingName', value)
    // }
  }
})
</script>
