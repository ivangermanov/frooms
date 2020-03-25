<template>
  <l-control v-if="mounted" position="topright" class="leaflet-bar">
    <a class="leaflet-draw-draw-circle">
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
      mounted: false
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

      const editableLayers = new L.GeoJSON()
      map.addLayer(editableLayers)
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
          circle: {
            showRadius: false,
            repeatMode: true
          },
          rectangle: {
            showArea: false,
            repeatMode: true
          },
          polyline: false,
          marker: false,
          circlemarker: false
        },
        edit: {
          featureGroup: editableLayers
        }
      }

      const drawControl = new L.Control.Draw(options)
      map.addControl(drawControl)

      map.on(L.Draw.Event.CREATED, function (e) {
        const layer = e.layer

        editableLayers.addLayer(layer)
        const json: any = editableLayers.toGeoJSON()
        console.log(json.features)
      })
    }
  }
})
</script>
