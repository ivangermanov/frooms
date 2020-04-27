<template>
  <client-only>
    <l-map
      ref="map"
      :options="mapOptions"
      style="height: 100%; padding: 10px; z-index: 0;"
    >
      <with-campus-data
        v-slot="{
          campusNames
        }"
      >
        <template>
          <with-rooms-data>
            <template
              v-slot="{
                roomLayers,
                postShape,
                putShapes,
                deleteShapes
              }"
            >
              <div v-if="mapObject">
                <l-draw
                  :map-object="mapObject"
                  :fetched-layers="roomLayers"
                  @addLayer="postShape"
                  @editLayers="putShapes"
                  @deleteLayers="deleteShapes"
                />
                <l-floors :campus-names="campusNames" :map-object="mapObject" />
              </div>
            </template>
          </with-rooms-data>
        </template>
      </with-campus-data>
    </l-map>
  </client-only>
</template>
<script lang="ts">
import Vue from 'vue'

import { CRS, Map } from 'leaflet'
import { LMap } from 'vue2-leaflet'

import WithCampusData from './campuses/WithCampusData.vue'
import WithRoomsData from './rooms/WithRoomsData.vue'
import LDraw from './rooms/draw/LDraw.vue'
import LFloors from './rooms/floors/LFloors.vue'

export default Vue.extend({
  components: {
    LMap,
    LDraw,
    LFloors,
    WithCampusData,
    WithRoomsData
  },
  data () {
    return {
      mapObject: (null as unknown) as Map,
      mapOptions: {
        crs: CRS.Simple,
        attributionControl: false,
        zoom: 2,
        minZoom: 2,
        maxZoom: 4
      }
    }
  },
  mounted () {
    this.$nextTick(() => {
      this.mapObject = (this.$refs.map as any).mapObject
    })
  }
})
</script>
