<template>
  <div class="control">
    <v-container>
      <v-menu
        ref="menu"
        v-model="menu"
        :close-on-content-click="false"
        :return-value.sync="dateTemp"
        transition="scale-transition"
        offset-y
      >
        <template v-slot:activator="{ on }">
          <v-text-field
            v-model="dateTemp"
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
        <v-date-picker
          v-model="dateTemp"
          :min="min"
          :max="max"
          no-title
          scrollable
        >
          <v-spacer />
          <v-btn text color="primary" @click="menu = false">
            Cancel
          </v-btn>
          <v-btn text color="primary" @click="$refs.menu.save(dateTemp)">
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
  props: {
    date: { type: String, default: '' },
    min: { type: String, default: '' },
    max: { type: String, default: '' }
  },
  data () {
    return {
      menu: false,
      dateTemp: ''
    }
  },
  watch: {
    date: {
      handler (value) {
        this.dateTemp = value
        this.setDate()
      },
      immediate: true
    },
    dateTemp: {
      handler () {
        this.update()
      },
      immediate: true
    },
    min () {
      this.setDate()
    },
    max () {
      this.setDate()
    }
  },
  methods: {
    update () {
      this.$emit('update:date', this.dateTemp)
    },
    setDate () {
      const min = moment(this.min)
      const max = moment(this.max)
      const current = moment(this.dateTemp)
      if (current.isAfter(max) || current.isBefore(min)) {
        this.dateTemp = min.format('YYYY-MM-DD')
      }
    }
  }
})
</script>
