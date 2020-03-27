<template>
  <no-ssr>
    <l-map
      :options="mapOptions"
      style="height: 100%; padding: 10px; z-index: 0;"
    >
      <l-draw-toolbar
        position="topright"
        :saved="saved"
        @emitShapes="saveShapes"
        @modifyShapes="$emit('save', $event)"
      />
      <l-image-overlay
        :url="overlayOptions.url"
        :bounds="overlayOptions.bounds"
      />
    </l-map>
  </no-ssr>
</template>
<script lang="ts">
import Vue from 'vue'
import { CRS, GeoJSON } from 'leaflet'
import { LMap, LImageOverlay } from 'vue2-leaflet'
import LDrawToolbar from './LDrawToolbar.vue'
import { RepositoryFactory } from '@/api/repositoryFactory'
import { GeoJSONToIRooms } from '@/types'

const RoomRepository = RepositoryFactory.room

export default Vue.extend({
  components: {
    LMap,
    LImageOverlay,
    LDrawToolbar
  },
  props: {
    saved: {
      type: Boolean,
      default: true
    }
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
      },
      floor: 2,
      buildingName: 'r1'
    }
  },
  created () {
    this.fetch()
  },
  methods: {
    async fetch () {
      const r = await RoomRepository.get()
    },
    async saveShapes (geoJSON: GeoJSON) {
      const payload = GeoJSONToIRooms(geoJSON)

      const success = await RoomRepository.postRooms(payload).catch(() => {})
      this.$emit('save', !!success)
    }
  }
})
</script>
