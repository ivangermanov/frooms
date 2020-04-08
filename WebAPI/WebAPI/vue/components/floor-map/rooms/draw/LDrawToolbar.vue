<script lang="ts">
import Vue from 'vue'
import {
  GeoJSON,
  Control,
  Draw,
  Map,
  Polyline
} from 'leaflet'
import 'leaflet-draw'
import 'leaflet-draw/dist/leaflet.draw-src.css'

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
  beforeMount () {
    this.$nextTick(() => {
      this.attachToolbar()
    })
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

      const drawControl = new Control.Draw(options)
      const map = this.mapObject
      map.addControl(drawControl)

      map.on(Draw.Event.CREATED, (e) => {
        const layer: Polyline = e.layer
        this.$emit('addLayer', layer)
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
