<template>
  <v-select
    :value="selection"
    :items="items"
    menu-props="auto"
    :label="label"
    hide-details
    :prepend-icon="icon"
    single-line
    @change="updateSelection"
  />
</template>

<script>

export default {
  props: {
    items: {
      type: Array,
      required: true
    },
    selection: {
      type: String,
      required: true
    },
    label: {
      type: String,
      required: false,
      default () {
        return 'Select an item'
      }
    },
    icon: {
      type: String,
      required: false,
      default () {
        return 'mdi-home'
      }
    }
  },

  methods: {
    updateSelection (value) {
      this.$emit('update:selection', value)
    }
  }
}
</script>
