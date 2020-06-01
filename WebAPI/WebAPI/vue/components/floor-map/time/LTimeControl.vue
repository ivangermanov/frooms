<template>
  <div class="control">
    <v-container>
      <v-menu
        ref="menu"
        v-model="menu"
        :close-on-content-click="false"
        :return-value.sync="timeTemp"
        transition="scale-transition"
        offset-y
      >
        <template v-slot:activator="{ on }">
          <v-text-field
            v-model="timeTemp"
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
        this.setTime()
      },
      immediate: true
    },
    timeTemp: {
      handler () {
        this.update()
      },
      immediate: true
    },
    min () {
      this.setTime()
    },
    max () {
      this.setTime()
    }
  },
  methods: {
    update () {
      this.$emit('update:time', this.timeTemp)
    },
    // TODO: This logic is also used in several places and is a candidate for composition API
    setTime () {
      const min = moment(this.min, 'HH:mm')
      const max = moment(this.max, 'HH:mm')
      const current = moment(this.timeTemp, 'HH:mm')
      if (current.isAfter(max) || current.isBefore(min)) {
        this.timeTemp = min.format('HH:mm')
      }
    }
  }
})
</script>
