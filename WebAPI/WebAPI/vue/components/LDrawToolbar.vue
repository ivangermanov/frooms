<template>
  <l-control v-if="mounted" position="topright" class="leaflet-bar">
    <a class="leaflet-draw-draw-circle" @click="emitShapes">
      <v-icon :dense="true" color="black" title="Save layers">
        mdi-check
      </v-icon>
    </a>
  </l-control>
</template>

<script lang="ts">
import Vue from 'vue'
import L from 'leaflet'
import 'leaflet-draw'
import 'leaflet-draw/dist/leaflet.draw-src.css'

export default Vue.extend({
  props: {
    position: {
      type: String,
      default: 'topright'
    }
  },
  data () {
    return {
      mounted: false,
      layers: L.geoJSON()
    }
  },
  beforeMount () {
    this.$nextTick(() => {
      this.attachToolbar()
      this.mounted = true
    })
  },
  methods: {
    attachToolbar () {
      const map: L.Map = (this.$parent as any).mapObject

      map.addLayer(this.layers)
      const options: L.Control.DrawConstructorOptions | any = {
        position: 'topright',
        draw: {
          polygon: {
            allowIntersection: false,
            showLength: false,
            showArea: false,
            drawError: {
              color: '#e1e100'
            },
            repeatMode: true
          },
          circle: false,
          rectangle: {
            showArea: false,
            repeatMode: true
          },
          polyline: false,
          marker: false,
          circlemarker: false
        },
        edit: {
          featureGroup: this.layers
        }
      }

      const drawControl = new L.Control.Draw(options)
      map.addControl(drawControl)

      map.on(L.Draw.Event.CREATED, (e) => {
        const layer = e.layer

        this.layers.addLayer(layer)
      })
    },
    emitShapes () {
      // const features = this.layers.toGeoJSON()

      // const payload: IRoom[] = [{
      //   number: 1,
      //   buildingName: 'test',
      //   floor: 1,
      //   points: [{ x: 10, y: 10 }],
      //   shape: EShape.RECTANGLE,
      //   capacity: 5
      // }]
      // console.log(features, payload)
      this.$emit('emitShapes', this.layers)
    }
  }
})
</script>
