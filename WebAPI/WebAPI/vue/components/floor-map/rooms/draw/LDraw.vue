<template>
  <l-draw-toolbar
    :map-object="mapObject"
    :layers="layers"
    position="topright"
    @addLayer="addLayer"
    @saveLayers="saveLayers"
  />
</template>

<script lang="ts">
import Vue from 'vue'
import { Map, geoJSON, Polyline } from 'leaflet'
import LDrawToolbar from './LDrawToolbar.vue'
import 'leaflet-draw'
import 'leaflet-draw/dist/leaflet.draw-src.css'

export default Vue.extend({
  components: {
    LDrawToolbar
  },
  props: {
    mapObject: {
      type: Map,
      required: true
    }
  },
  data () {
    return {
      layers: geoJSON()
    }
  },
  beforeMount () {
    const map = this.mapObject
    map.addLayer(this.layers)
  },
  methods: {
    addLayer (layer: Polyline) {
      this.layers.addLayer(layer)
      this.$emit('addLayer', layer)
    },
    saveLayers () {
      this.$emit('saveLayers', this.layers)
    }
  }
})
</script>
