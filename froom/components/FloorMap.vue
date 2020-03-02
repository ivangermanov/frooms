<template>
  <div style="height: 100%; padding: 10px;">
    <no-ssr>
      <l-map :options="mapOptions">
        <l-image-overlay :url="url" :bounds="bounds" />
      </l-map>
    </no-ssr>
  </div>
</template>
<script lang="ts">
import Vue from 'vue'
import { CRS } from 'leaflet'
import { LMap, LImageOverlay } from 'vue2-leaflet'
import png from '~/mock/floor.png'

export default Vue.extend({
  components: {
    LMap,
    LImageOverlay
  },
  data () {
    return {
      mapOptions: {
        crs: CRS.Simple,
        minZoom: 2,
        maxZoom: 4,
        maxBounds: [[0, 0], [1416, 512]]
      },
      url: png,
      bounds: [[0, 0], [1416, 512]]
    }
  }
})
</script>
