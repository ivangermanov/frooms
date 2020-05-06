<template>
  <v-date-picker
    :value="date"
    :min="minDate"
    :max="maxDate"
    @change="updateDate"
  />
</template>

<script>
import moment from 'moment'

export default {
  props: {
    date: {
      type: String,
      required: true
    }
  },

  computed: {
    minDate () {
      return moment().format('YYYY-MM-DD')
    },

    maxDate () {
      // TODO: calculate based on semester
      return moment().add(3, 'M').format('YYYY-MM-DD')
    }
  },

  methods: {
    updateDate (value) {
      this.$emit('update:date', value)
    }
  }
}
</script>
