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
    },
    fetchedLayers: {
      type: Object,
      required: true,
      default: {} as { [key: string]: GeoJSON.Feature }
    }
  },
  data () {
    return {
      layers: geoJSON()
    }
  },
  watch: {
    fetchedLayers (layers: { [key: string]: GeoJSON.Feature }) {
      console.log(layers)
      const values = Object.values(layers)
      this.layers.clearLayers()
      values.forEach((layer) => {
        this.layers.addData(layer)
      })
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
