<template>
  <v-date-picker
    v-model="dateTemp"
    :min="min"
    :max="max"
  />
</template>

<script>
import moment from 'moment'

export default {
  props: {
    date: { type: String, default: '' },
    min: { type: String, default: '' },
    max: { type: String, default: '' }
  },
  data () {
    return {
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
}
</script>
