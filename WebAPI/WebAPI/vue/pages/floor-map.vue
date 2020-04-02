<template>
  <floor-map />
</template>

<script lang="ts">
import Vue from 'vue'
import { mapMutations } from 'vuex'
import FloorMap from '@/components/FloorMap/FloorMap.vue'

export default Vue.extend({
  components: {
    FloorMap
  },
  computed: {
    saved () : Boolean {
      return this.$store.state.roomAdmin.saved
    }
  },
  beforeRouteLeave (_to, _from, next) {
    let answer = true
    if (!this.saved) {
      answer = window.confirm(
        'Your unsaved changes will be lost! Do you really want to leave?'
      )
    }
    if (answer) {
      this.setSaved(true)
      next()
    }
  },
  methods: {
    ...mapMutations({
      setSaved: 'roomAdmin/setSaved'
    })
  }
})
</script>
