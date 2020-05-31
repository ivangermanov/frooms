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
import { Map, geoJSON, GeoJSON } from 'leaflet'
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
      if (!info.role) {
        return true
      }
      return info.role.some(role => role === 'admin')
    }
  },
  watch: {
    fetchedLayers (layers: { [key: string]: GeoJSON.Feature }) {
      this.drawLayers(layers)
    }
  },
  beforeMount () {
    this.mapObject.addLayer(this.allLayers)
  },
  beforeDestroy () {
    this.mapObject.removeLayer(this.allLayers)
  },
  methods: {
    drawLayers (layers: { [key: string]: GeoJSON.Feature }) {
      const allLayers = this.allLayers
      allLayers.clearLayers()
      // console.log(allLayers, layers)

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
    },
    addLayer (geoJSON: GeoJSON.Feature<any>) {
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
