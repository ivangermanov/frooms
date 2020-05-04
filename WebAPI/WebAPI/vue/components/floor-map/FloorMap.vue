<template>
  <client-only>
    <l-map
      ref="map"
      :options="mapOptions"
      style="height: 100%; z-index: 0;"
    >
      <l-control-zoom position="topright" />
      <with-campus-data
        v-slot="{
          campusNames
        }"
      >
        <template>
          <with-building-data
            v-slot="{
              buildings
            }"
            :campus-name="campusName"
          >
            <template>
              <with-room-data
                :campus-name="campusName"
                :building-name="buildingName"
                :floor-number="floorNumber"
              >
                <template
                  v-slot="{
                    roomLayers,
                    postShape,
                    putShapes,
                    deleteShapes
                  }"
                >
                  <div v-if="mapObject">
                    <l-campus-control :campus-name.sync="campusName" :campuses="campusNames" position="topleft" />
                    <l-building-control :building-name.sync="buildingName" :buildings="buildings.map(building => building.name)" position="topleft" />
                    <l-draw
                      position="topright"
                      :map-object="mapObject"
                      :fetched-layers="roomLayers"
                      @addLayer="postShape"
                      @editLayers="putShapes"
                      @deleteLayers="deleteShapes"
                    />
                    <l-floors-control
                      position="bottomright"
                      :campus-names="campusNames"
                      :buildings="buildings"
                      :map-object="mapObject"
                    />
                  </div>
                </template>
              </with-room-data>
            </template>
          </with-building-data>
        </template>
      </with-campus-data>
    </l-map>
  </client-only>
</template>
<script lang="ts">
import Vue from 'vue'

import { CRS, Map } from 'leaflet'
import { LMap, LControlZoom } from 'vue2-leaflet'

import WithCampusData from './campuses/WithCampusData.vue'
import WithBuildingData from './buildings/WithBuildingData.vue'
import WithRoomData from './rooms/WithRoomData.vue'
import LDraw from './rooms/draw/LDraw.vue'
import LFloorsControl from './rooms/floors/LFloorsControl.vue'
import LCampusControl from './campuses/LCampusControl.vue'
import LBuildingControl from './buildings/LBuildingControl.vue'

export default Vue.extend({
  components: {
    LMap,
    LDraw,
    LControlZoom,
    LCampusControl,
    LBuildingControl,
    LFloorsControl,
    WithCampusData,
    WithBuildingData,
    WithRoomData
  },
  data () {
    return {
      mapObject: (null as unknown) as Map,
      mapOptions: {
        crs: CRS.Simple,
        attributionControl: false,
        zoom: 2,
        minZoom: 2,
        maxZoom: 4,
        zoomControl: false
      },
      campusName: '',
      buildingName: '',
      floorNumber: ''
    }
  },
  mounted () {
    this.$nextTick(() => {
      this.mapObject = (this.$refs.map as any).mapObject
    })
  }
})
</script>
