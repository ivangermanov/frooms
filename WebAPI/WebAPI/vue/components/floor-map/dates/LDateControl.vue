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
        <v-date-picker v-model="date" :min="minDate" :max="maxDate" no-title scrollable>
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
import moment from 'moment'
export default Vue.extend({
  data () {
    return {
      date: new Date().toISOString().substr(0, 10),
      menu: false
    }
  },
  computed: {
    minDate () {
      return moment().format('YYYY-MM-DD')
    },
    maxDate () {
      return moment().add(3, 'M').format('YYYY-MM-DD')
    },
    dateIso () {
      const date = this.date as string
      return moment(date).toISOString()
    }
  },
  watch: {
    dateIso (value) {
      this.updateDate(value)
    }
  },
  methods: {
    updateDate (value: string) {
      this.$emit('update:date', value)
    }
  }
})
</script>
