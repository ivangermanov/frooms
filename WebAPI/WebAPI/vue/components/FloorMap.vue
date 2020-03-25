<template>
  <no-ssr>
    <l-map
      :options="mapOptions"
      style="height: 100%; padding: 10px; z-index: 0;"
    >
      <l-draw-toolbar position="topright" />
      <l-image-overlay
        :url="overlayOptions.url"
        :bounds="overlayOptions.bounds"
      />
    </l-map>
  </no-ssr>
</template>
<script lang="ts">
import Vue from 'vue'
import { CRS } from 'leaflet'
import { LMap, LImageOverlay } from 'vue2-leaflet'
import LDrawToolbar from './LDrawToolbar.vue'

export default Vue.extend({
  components: {
    LMap,
    LImageOverlay,
    LDrawToolbar
  },
  data () {
    return {
      mapOptions: {
        crs: CRS.Simple,
        attributionControl: false,
        zoom: 2,
        minZoom: 2,
        maxZoom: 4,
        maxBounds: [
          [0, 0],
          [1416, 512]
        ]
      },
      overlayOptions: {
        url: 'https://i.ibb.co/bQYTGBR/floor.png',
        bounds: [
          [0, 0],
          [1416, 512]
        ]
      }
    }
  }
})
</script>
