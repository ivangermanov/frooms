<template>
  <div class="control">
    <v-container>
      <v-menu
        ref="menu"
        v-model="menu"
        :close-on-content-click="false"
        transition="scale-transition"
        offset-y
      >
        <template v-slot:activator="{ on }">
          <v-text-field
            :value="timeTemp"
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
        <v-time-picker
          v-model="timeTemp"
          :min="min"
          :max="max"
          scrollable
          :format="'24hr'"
          @input="resetMinutes"
          @click:minute="$refs.menu.save(timeTemp)"
        />
      </v-menu>
    </v-container>
  </div>
</template>

<script lang="ts">
import Vue from 'vue'
import moment from 'moment'

export default Vue.extend({
  props: {
    icon: { type: String, default: 'mdi-clock' },
    label: { type: String, default: 'Time' },
    time: { type: String, default: '' },
    min: { type: String, default: '' },
    max: { type: String, default: '' }
  },
  data () {
    return {
      timeTemp: '',
      menu: false
    }
  },
  watch: {
    time: {
      handler (value) {
        this.timeTemp = value
      },
      immediate: true
    },
    timeTemp: {
      handler () {
        this.update()
      },
      immediate: true
    }
  },
  methods: {
    update () {
      this.$emit('update:time', this.timeTemp)
    },
    resetMinutes (value: string) {
      const hours = moment(value, 'HH:mm').hours()
      const minutes = this.timeTemp.split(':')[1]
      const newTime = moment(`${hours}:${minutes}`, 'HH:mm')
      const max = moment(this.max, 'HH:mm')
      if (newTime.isAfter(max)) {
        this.timeTemp = `${hours}:00`
      }
    }
  }
})
</script>
