<template>
  <div class="control">
    <v-container>
      <v-menu
        ref="menu"
        v-model="menu"
        :close-on-content-click="false"
        :return-value.sync="date"
        transition="scale-transition"
        offset-y
      >
        <template v-slot:activator="{ on }">
          <v-text-field
            v-model="date"
            label="Date"
            :dark="false"
            :light="true"
            :dense="true"
            prepend-icon="mdi-calendar"
            readonly
            hide-details="auto"
            v-on="on"
          />
        </template>
        <v-date-picker v-model="date" no-title scrollable>
          <v-spacer />
          <v-btn text color="primary" @click="menu = false">
            Cancel
          </v-btn>
          <v-btn text color="primary" @click="$refs.menu.save(date)">
            OK
          </v-btn>
        </v-date-picker>
      </v-menu>
    </v-container>
  </div>
</template>

<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
  data () {
    return {
      date: new Date().toISOString().substr(0, 10),
      menu: false
    }
  },
  methods: {
    updateBuildingName (value: string) {
      this.$emit('update:buildingName', value)
    }
  }
})
</script>
