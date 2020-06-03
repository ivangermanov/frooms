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
import { Map, geoJSON, GeoJSON, PathOptions, Layer } from 'leaflet'
import { IUser } from 'types'
import LDrawControl from './LDrawControl.vue'
import 'leaflet-draw'
import 'leaflet-draw/dist/leaflet.draw-src.css'

const availableColor = 'green'
const unavailableColor = 'red'
const weight = 1

function getColor (feature: any): PathOptions {
  switch (feature.properties?.isAvailable) {
    case true: return { color: availableColor, weight }
    case false: return { color: unavailableColor, weight }
    default: return { color: availableColor, weight }
  }
}

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
    },
    selectedRoom: {
      type: String,
      required: false,
      default: null

    }
  },
  data () {
    return {
      allLayers: null as unknown as GeoJSON,
      selectedRoomTemp: null
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
    selectedRoom: {
      handler (value) {
        this.selectedRoomTemp = value
      },
      immediate: true
    },
    fetchedLayers (layers: { [key: string]: GeoJSON.Feature }) {
      this.drawLayers(layers)
    }
  },
  beforeMount () {
    this.allLayers = geoJSON(undefined, { style: getColor, onEachFeature: this.onRoomClick })
    this.mapObject.addLayer(this.allLayers)
  },
  beforeDestroy () {
    this.mapObject.removeLayer(this.allLayers)
  },
  methods: {
    onRoomClick (feature: GeoJSON.Feature<GeoJSON.Geometry, any>, layer: Layer) {
      layer.on('click', () => {
        if (feature.properties.isAvailable) {
          this.selectedRoomTemp = feature.properties.number
          this.$emit('select-room', this.selectedRoomTemp)
        }
      })
    },
    drawLayers (layers: { [key: string]: GeoJSON.Feature }) {
      const allLayers = this.allLayers
      allLayers.clearLayers()

      allLayers.eachLayer((layer: any) => {
        const geoJson: GeoJSON.Feature = (layer as any).toGeoJSON()
        const number = geoJson.properties?.number

        if (number && layers[number]) {
          allLayers.removeLayer(layer)
          Object.assign(geoJson, layers[number])
          allLayers.addData(geoJson)
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
