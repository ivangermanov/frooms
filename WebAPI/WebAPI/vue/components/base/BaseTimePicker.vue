<template>
  <v-dialog
    :ref="`dialog-time-picker-${_uid}`"
    v-model="modal"
    :return-value.sync="timeTemp"
    width="290px"
  >
    <template v-slot:activator="{ on }">
      <v-text-field
        v-model="timeTemp"
        :label="label"
        :prepend-icon="icon"
        readonly
        v-on="on"
      />
    </template>
    <v-time-picker
      v-if="modal"
      v-model="timeTemp"
      :min="min"
      :max="max"
      scrollable
      :format="'24hr'"
      full-width
      @click:minute="$refs[`dialog-time-picker-${_uid}`].save(timeTemp)"
    />
  </v-dialog>
</template>

<script>
import moment from 'moment'

export default {
  props: {
    icon: { type: String, default: 'mdi-clock' },
    label: { type: String, default: 'Pick a time' },
    time: { type: String, default: '' },
    min: { type: String, default: '' },
    max: { type: String, default: '' }
  },

  data () {
    return {
      modal: false,
      timeTemp: ''
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
}
</script>
