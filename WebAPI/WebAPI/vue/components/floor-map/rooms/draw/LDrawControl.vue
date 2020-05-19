<script lang="ts">
import Vue from 'vue'
import {
  GeoJSON,
  Control,
  Draw,
  Map,
  Polyline,
  geoJSON,
  Popup
} from 'leaflet'
import 'leaflet-draw'
import 'leaflet-draw/dist/leaflet.draw-src.css'
import './popups/editablePopup'

export default Vue.extend({
  props: {
    position: {
      type: String,
      default: 'topright'
    },
    layers: {
      type: GeoJSON,
      required: true
    },
    mapObject: {
      type: Map,
      required: true
    }
  },
  data () {
    return {
      drawControl: {} as Control.Draw,
      tempLayers: geoJSON()
    }
  },
  beforeMount () {
    this.$nextTick(() => {
      this.attachToolbar()
    })

    this.mapObject.addLayer(this.tempLayers)
  },
  beforeDestroy () {
    this.mapObject.removeLayer(this.tempLayers)
    this.mapObject.removeControl(this.drawControl)
  },
  methods: {
    attachToolbar () {
      const options: Control.DrawConstructorOptions | any = {
        position: 'topright',
        draw: {
          polygon: {
            allowIntersection: false,
            showLength: false,
            showArea: false,
            drawError: {
              color: '#e1e100'
            },
            repeatMode: false
          },
          circle: false,
          rectangle: {
            showArea: false,
            repeatMode: false
          },
          polyline: false,
          marker: false,
          circlemarker: false
        },
        edit: {
          featureGroup: this.layers
        }
      }

      const drawControl = new Control.Draw(options)
      const map = this.mapObject
      map.addControl(drawControl)
      this.drawControl = drawControl

      map.on(Draw.Event.CREATED, (e) => {
        const layer: Polyline = e.layer
        const content = 'Enter room number'
        layer.bindPopup(content, {
          editable: true,
          autoClose: false,
          closeOnEscapeKey: false,
          closeButton: false,
          closeOnClick: false
        } as any)
        this.tempLayers.addLayer(layer)
        layer.getPopup()!.on('save', (e: any) => {
          const geoJSON = layer.toGeoJSON()
          geoJSON.properties.number = e.value
          this.$emit('addLayer', geoJSON)
          this.tempLayers.removeLayer(layer)
        })
        layer.openPopup()
      })
      map.on(Draw.Event.EDITSTART, () => {
        this.$emit('editStart')
      })
      map.on(Draw.Event.EDITSTOP, () => {
        this.$emit('editStop')
      })
      map.on(Draw.Event.EDITED, (e) => {
        const layers = (e as any).layers
        this.$emit('editLayers', layers)
      })
      map.on(Draw.Event.DELETESTART, () => {
        this.$emit('deleteStart')
      })
      map.on(Draw.Event.DELETESTOP, () => {
        this.$emit('deleteStop')
      })
      map.on(Draw.Event.DELETED, (e) => {
        const layers = (e as any).layers
        this.$emit('deleteLayers', layers)
      })
    }
  },
  render (): any {
    return null
  }
})
</script>
