<template>
  <no-ssr>
    <l-map />
  </no-ssr>
</template>
<script lang="ts">
import Vue from 'vue'
import { LMap, LTileLayer, LMarker } from 'vue2-leaflet'

export default Vue.extend({
  components: {
    LMap,
    LTileLayer,
    LMarker
  }
})
</script>
