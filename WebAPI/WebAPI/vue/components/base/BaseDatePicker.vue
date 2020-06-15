<template>
  <v-date-picker
    v-model="dateTemp"
    :min="min"
    :max="max"
    :allowed-dates="allowedDates"
  />
</template>

<script lang="ts">
import Vue from 'vue'
import moment from 'moment'
import { PropType } from '@vue/composition-api'
import { DayOfWeek } from '@/types'

export default Vue.extend({
  props: {
    date: { type: String, default: '' },
    min: { type: String, default: '' },
    max: { type: String, default: '' },
    availableDays: { type: Array as PropType<Array<DayOfWeek>>, default: () => [] }
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
    },
    allowedDates (val: string) {
      const weekDay = moment(val).weekday()
      return this.availableDays.includes(weekDay)
    }
  }
})
</script>
