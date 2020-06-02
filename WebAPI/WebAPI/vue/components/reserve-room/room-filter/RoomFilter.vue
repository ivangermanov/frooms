<template>
  <v-card>
    <v-card-title class="headline">
      Room Filter
    </v-card-title>
    <v-card-text>
      <filter-option :campuses="campuses" :initial="initial" @update-reservation-details="updateReservationDetailsEvent" />
    </v-card-text>
  </v-card>
</template>

<script>
import FilterOption from './FilterOption.vue'

export default {
  components: { FilterOption },

  props: {
    campuses: {
      type: Array,
      required: true,
      default () {
        return []
      }
    },
    initial: {
      type: Object,
      required: true,
      default: () => {}
    }
  },

  methods: {
    updateReservationDetailsEvent (value) {
      this.$emit('update-reservation-details', value)
    }
  }
}
</script>
