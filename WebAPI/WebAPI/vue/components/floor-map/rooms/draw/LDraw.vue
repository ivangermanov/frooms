<template>
  <fragment v-if="isAdmin">
    <l-draw-control
      :map-object="mapObject"
      :layers="allLayers"
      :position="position"
      @addLayer="addLayer"
      @editStart="setEditMode(true)"
      @editStop="setEditMode(false)"
      @deleteStart="setDeleteMode(true)"
      @deleteStop="setDeleteMode(false)"
      @editLayers="editLayers"
      @deleteLayers="deleteLayers"
    />
  </fragment>
</template>

<script lang="ts">
import Vue from 'vue'
import { mapMutations } from 'vuex'
import { Map, geoJSON, GeoJSON, Polyline } from 'leaflet'
import { IUser } from 'types'
import LDrawControl from './LDrawControl.vue'
import 'leaflet-draw'
import 'leaflet-draw/dist/leaflet.draw-src.css'

export default Vue.extend({
  components: {
    LDrawControl
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
    },
    position: {
      type: String,
      required: true
    }
  },
  data () {
    return {
      allLayers: geoJSON()
    }
  },
  computed: {
    isAdmin (): Boolean {
      const info: IUser = this.$store.state.user.info
      if (!info.role) { return true }
      return info.role.some(role => role === 'admin')
    }
  },
  watch: {
    fetchedLayers (layers: { [key: string]: GeoJSON.Feature }) {
      this.drawLayers(layers)
    }
  },
  beforeMount () {
    const map = this.mapObject
    map.addLayer(this.allLayers)
  },
  beforeDestroy () {
    this.allLayers.clearLayers()
  },
  methods: {
    drawLayers (layers: { [key: string]: GeoJSON.Feature}) {
      setTimeout(() => {
        const allLayers = this.allLayers
        allLayers.clearLayers()

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
      }, 2000)
    },
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
    deleteLayers (layers: GeoJSON) {
      this.$emit('deleteLayers', layers)
    },
    ...mapMutations({
      setEditMode: 'roomAdmin/setEditMode',
      setDeleteMode: 'roomAdmin/setDeleteMode'
    })
  }
})
</script>
