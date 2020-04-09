<template>
  <floor-map />
</template>

<script lang="ts">
import Vue from 'vue'
import FloorMap from '@/components/floor-map/FloorMap.vue'

export default Vue.extend({
  components: {
    FloorMap
  },
  computed: {
    editMode () : Boolean {
      return this.$store.state.roomAdmin.editMode
    },
    deleteMode () : Boolean {
      return this.$store.state.roomAdmin.deleteMode
    }
  },
  beforeRouteLeave (_to, _from, next) {
    let answer = true
    if (this.editMode || this.deleteMode) {
      answer = window.confirm(
        'Your unsaved changes will be lost! Do you really want to leave?'
      )
    }
    if (answer) {
      next()
    }
  }
})
</script>
