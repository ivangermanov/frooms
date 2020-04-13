<template>
  <div />
</template>
<script lang="ts">
import Vue from 'vue'

import './L.Control.Basemaps'
import L, { Map } from 'leaflet'

export default Vue.extend({
  props: {
    mapObject: {
      type: Map,
      required: true
    }
  },
  mounted () {
    const basemaps = [
      L.imageOverlay('https://i.ibb.co/yP7k1X2/1e.png', [
        [0, 0],
        [1416, 512]
      ], {
        alt: '1e'
      }),
      L.imageOverlay('https://i.ibb.co/bQYTGBR/floor.png', [
        [0, 0],
        [1416, 512]
      ], {
        alt: '2e'
      }),
      L.imageOverlay('https://i.ibb.co/FnTZ7cR/3e.png', [
        [0, 0],
        [1416, 512]
      ], {
        alt: '3e'
      }),
      L.imageOverlay('https://i.ibb.co/0D4ryqr/4e.png', [
        [0, 0],
        [1416, 512]
      ], {
        alt: '4e'
      })]

    const map = this.mapObject
    map.addControl(L.control.basemaps({
      basemaps
    }))
  }
})
</script>
