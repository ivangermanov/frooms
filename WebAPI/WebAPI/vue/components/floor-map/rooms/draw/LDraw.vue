<template>
  <l-draw-toolbar
    :map-object="mapObject"
    :layers="allLayers"
    position="topright"
    @addLayer="addLayer"
    @editStart="setEditMode(true)"
    @editStop="setEditMode(false)"
    @editLayers="editLayers"
  />
</template>

<script lang="ts">
import Vue from 'vue'
import { mapMutations } from 'vuex'
import { Map, geoJSON, GeoJSON, Polyline } from 'leaflet'
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
      allLayers: geoJSON()
    }
  },
  watch: {
    fetchedLayers (layers: { [key: string]: GeoJSON.Feature }) {
      const allLayers = this.allLayers

      allLayers.eachLayer((layer: any) => {
        const geoJSON: GeoJSON.Feature = (layer as any).toGeoJSON()
        const number = geoJSON.properties?.number

        if (number && layers[number]) {
          allLayers.removeLayer(layer)
          Object.assign(geoJSON, layers[number])
          allLayers.addData(geoJSON)
          delete layers[number]
        }
      })

      const values = Object.values(layers)
      values.forEach((layer) => {
        allLayers.addData(layer)
      })
    }
  },
  beforeMount () {
    const map = this.mapObject
    map.addLayer(this.allLayers)
  },
  methods: {
    addLayer (layer: Polyline) {
      const randNumber = Math.random()
        .toString(36)
        .substring(7)

      const geoJSON = layer.toGeoJSON()
      // TODO: Remove random number
      geoJSON.properties.number = randNumber

      this.allLayers.addData(geoJSON)
      this.$emit('addLayer', geoJSON)
    },
    editLayers (layers: GeoJSON) {
      this.$emit('editLayers', layers)
    },
    ...mapMutations({
      setEditMode: 'roomAdmin/setEditMode'
    })
  }
})
</script>
