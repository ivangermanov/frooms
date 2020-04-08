<template>
  <client-only>
    <l-map
      ref="map"
      :options="mapOptions"
      style="height: 100%; padding: 10px; z-index: 0;"
    >
      <with-rooms-data v-if="mapObject">
        <template
          v-slot="{
            roomLayers,
            postShape,
            putShapes
          }"
        >
          <l-draw
            :fetched-layers="roomLayers"
            :map-object="mapObject"
            @addLayer="postShape"
            @editLayers="putShapes"
          />
        </template>
      </with-rooms-data>
      <l-image-overlay
        :url="overlayOptions.url"
        :bounds="overlayOptions.bounds"
      />
    </l-map>
  </client-only>
</template>
<script lang="ts">
import Vue from 'vue'

import { CRS, Map } from 'leaflet'
import { LMap, LImageOverlay } from 'vue2-leaflet'
import WithRoomsData from './rooms/WithRoomsData.vue'
import LDraw from './rooms/draw/LDraw.vue'

export default Vue.extend({
  components: {
    LMap,
    LImageOverlay,
    LDraw,
    WithRoomsData
  },
  data () {
    return {
      mapObject: (null as unknown) as Map,
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
  },
  mounted () {
    this.$nextTick(() => {
      this.mapObject = (this.$refs.map as any).mapObject
    })
  }
})
</script>
