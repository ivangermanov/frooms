<template>
  <div style="display: none;" />
</template>

<script>
import L from 'leaflet'
import 'leaflet-draw'
import 'leaflet-draw/dist/leaflet.draw-src.css'

export default {
  props: {
    position: {
      type: String,
      default: 'topright'
    }
  },
  mounted () {
    this.$nextTick(() => {
      const map = this.$parent.$parent.$refs.map.mapObject

      const editableLayers = new L.FeatureGroup()
      map.addLayer(editableLayers)

      const options = {
        position: 'topright',
        draw: {
          polyline: false,
          polygon: {
            allowIntersection: false,
            showLength: false,
            drawError: {
              color: '#e1e100'
            },
            shapeOptions: {
              color: '#bada55'
            }
          },
          circle: { showRadius: false },
          rectangle: { showArea: false },
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
      })
    })
  }
}
</script>
