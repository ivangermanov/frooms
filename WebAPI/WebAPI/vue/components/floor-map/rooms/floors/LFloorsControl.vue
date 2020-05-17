<template>
  <div />
</template>
<script lang="ts">
import Vue from 'vue'
import { IFloor } from 'types'
import { sortedIndexBy } from 'lodash'

import './L.Control.Basemaps'
import { Map, control, ImageOverlay, imageOverlay, latLngBounds } from 'leaflet'

export default Vue.extend({
  props: {
    mapObject: {
      type: Map,
      required: true
    },
    floors: {
      type: Array,
      required: false,
      default: () => [] as IFloor[]
    },
    position: {
      type: String,
      required: true
    }
  },
  data () {
    return {
      baseMaps: [] as Array<ImageOverlay>,
      control: null,
      floorNumber: null
    }
  },
  watch: {
    floors: {
      handler (value: Array<IFloor>) {
        if (this.control) { this.mapObject.removeControl(this.control as any) }
        this.$emit('fetchedFloors', false)
        this.baseMaps = []
        const promises: Promise<any>[] = []
        value.forEach((floor) => {
          promises.push(this.loadBasemap(floor))
        })
        Promise.all(promises).then(() => {
          this.$emit('fetchedFloors', true)
        })
      },
      deep: true,
      immediate: true
    },
    floorNumber: {
      handler (value: string) {
        this.$emit('update:floorNumber', value)
      }
    }
  },
  mounted () {
    this.mapObject.on('baselayerchange', (layer) => { this.floorNumber = (layer as any).options.alt })
  },
  beforeDestroy () {
    this.mapObject.off('baselayerchange')
  },
  methods: {
    reloadOverlays () {
      const map = this.mapObject
      const baseMaps = this.baseMaps

      if (this.control) { map.removeControl(this.control as any) }

      this.control = (control as any).basemaps({
        basemaps: baseMaps,
        position: this.position
      })
      map.addControl(this.control as any)
    },
    loadBasemap (floor: IFloor) {
      const baseMaps = this.baseMaps
      const map = this.mapObject
      const image = new Image()
      const promise = new Promise((resolve) => {
        image.onload = () => {
          const southWest = map.unproject([image.naturalWidth, 0], 2)
          const northEast = map.unproject([0, image.naturalHeight], 2)
          const bounds = latLngBounds(southWest, northEast)

          const options = {
            alt: floor.number,
            order: floor.order
          }

          const basemap = imageOverlay(floor.url, bounds, options)
          baseMaps.splice(sortedIndexBy(baseMaps, basemap, 'options.order'), 0, basemap)
          this.reloadOverlays()
          resolve(true)
        }

        image.src = floor.url
      })

      return promise
    }
  }
})
</script>
