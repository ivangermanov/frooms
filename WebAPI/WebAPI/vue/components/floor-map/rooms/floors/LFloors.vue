<template>
  <div />
</template>
<script lang="ts">
import Vue from 'vue'
import { IFloor } from 'types'
import { sortedIndexBy } from 'lodash'

import './L.Control.Basemaps'
import { Map, control, CRS, ImageOverlay, imageOverlay, LatLngBoundsExpression, ImageOverlayOptions, latLngBounds } from 'leaflet'

export default Vue.extend({
  props: {
    mapObject: {
      type: Map,
      required: true
    },
    floors: {
      type: Array,
      required: false,
      default: () => [
        { url: 'https://i.ibb.co/f0nYv9G/bg.png', floor: 'BG', order: 0 },
        { url: 'https://i.ibb.co/yP7k1X2/1e.png', floor: '1e', order: 1 },
        { url: 'https://i.ibb.co/bQYTGBR/floor.png', floor: '2e', order: 2 },
        { url: 'https://i.ibb.co/FnTZ7cR/3e.png', floor: '3e', order: 3 },
        { url: 'https://i.ibb.co/0D4ryqr/4e.png', floor: '4e', order: 4 }
      ] as IFloor[]
    }
  },
  data () {
    return {
      baseMaps: [] as Array<ImageOverlay>,
      control: null
    }
  },
  watch: {
    floors: {
      handler (value: Array<IFloor>) {
        this.baseMaps = []
        value.forEach((floor) => {
          this.loadBasemap(floor)
        })
      },
      deep: true,
      immediate: true
    }
  },
  methods: {
    reloadOverlays () {
      const map = this.mapObject
      const baseMaps = this.baseMaps

      if (this.control) { map.removeControl(this.control as any) }

      this.control = (control as any).basemaps({
        basemaps: baseMaps
      })
      map.addControl(this.control as any)
    },
    loadBasemap (floor: IFloor) {
      const baseMaps = this.baseMaps
      const map = this.mapObject
      const image = new Image()
      image.onload = () => {
        const topLeft = map.layerPointToLatLng([0, 0])
        const bottomRight = map.layerPointToLatLng([image.naturalWidth, image.naturalHeight])
        // console.log(topLeft, bottomRight)
        const bounds = latLngBounds(topLeft, bottomRight)

        const options = {
          alt: floor.floor,
          order: floor.order
        }
        // console.log(floor.floor, bounds[0], bounds[1])
        const basemap = imageOverlay(floor.url, bounds, options)
        baseMaps.splice(sortedIndexBy(baseMaps, basemap, 'options.order'), 0, basemap)
        this.reloadOverlays()
      }
      image.src = floor.url
    }
  }
})
</script>
