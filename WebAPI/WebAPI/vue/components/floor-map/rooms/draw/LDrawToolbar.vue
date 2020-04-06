<!-- <template>
  <l-control v-if="mounted" position="topright" class="leaflet-bar">
    <a class="leaflet-draw-draw-circle" @click="saveLayers">
      <v-icon :dense="true" color="black" title="Save layers">
        mdi-check
      </v-icon>
    </a>
  </l-control>
</template> -->

<script lang="ts">
import Vue from 'vue'
import { GeoJSON, Control, Draw, Map, Polyline } from 'leaflet'
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
  // data () {
  //   return {
  //     mounted: false
  //   }
  // },
  beforeMount () {
    this.$nextTick(() => {
      this.attachToolbar()
      // this.mounted = true
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
      map.on(Draw.Event.EDITSTOP, (e) => {
        const layer = e.layer
        this.$emit('editStop', layer)
      })
      map.on(Draw.Event.EDITED, (e) => {
        console.log(e)
        const layer = e.layer
        this.$emit('editLayers', layer)
      })
    }
    // saveLayers () {
    //   this.$emit('saveLayers')
    // }
  },
  render (): any {
    return null
  }
})
</script>
