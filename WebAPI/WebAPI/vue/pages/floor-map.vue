<template>
  <floor-map :saved="saved" @save="saved=$event" />
</template>

<script>
import FloorMap from '@/components/FloorMap/FloorMap'

export default {
  components: {
    FloorMap
  },
  data () {
    return {
      saved: true
    }
  },
  beforeRouteLeave (_to, _from, next) {
    if (!this.saved) {
      const answer = window.confirm('Your unsaved changes will be lost! Do you really want to leave?')
      if (answer) {
        next()
      } else {
        next(false)
      }
    } else {
      next()
    }
  }
}
</script>
