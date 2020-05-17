<template>
  <client-only>
    <l-map
      ref="map"
      :options="mapOptions"
      style="height: 100vh; z-index: 0;"
    >
      <l-control-zoom position="topright" />

      <with-room-data
        :campus-name="campusName"
        :building-name="buildingName"
        :floor-number="floorNumber"
      >
        <template
          v-slot="{
            roomLayers,
            floors,
            postShape,
            putShapes,
            deleteShapes
          }"
        >
          <fragment v-if="mapObject">
            <l-campus-control
              :campus-name.sync="campusName"
              :campuses="campusNames"
              position="topleft"
            />
            <l-building-control
              :building-name.sync="buildingName"
              :buildings="buildings.map(building => building.name)"
              position="topleft"
            />
            <l-floors-control
              :map-object="mapObject"
              :campus-names="campusNames"
              :buildings="buildings"
              :floors="floors"
              :floor-number.sync="floorNumber"
              position="bottomright"
              @fetchedFloors="(value) => floorImagesReady = value"
            />
            <fragment v-if="floorImagesReady">
              <l-draw
                position="topright"
                :map-object="mapObject"
                :fetched-layers="roomLayers"
                @addLayer="postShape"
                @editLayers="putShapes"
                @deleteLayers="deleteShapes"
              />
            </fragment>
          </fragment>
        </template>
      </with-room-data>
    </l-map>
  </client-only>
</template>
<script lang="ts">
import Vue from 'vue'

import { CRS, Map } from 'leaflet'
import { LMap, LControlZoom } from 'vue2-leaflet'

import { toRefs, watch } from '@vue/composition-api'
import LDraw from './rooms/draw/LDraw.vue'
import LFloorsControl from './rooms/floors/LFloorsControl.vue'
import LCampusControl from './campuses/LCampusControl.vue'
import LBuildingControl from './buildings/LBuildingControl.vue'
import WithRoomData from './rooms/WithRoomData.vue'
import useCampusData from '@/composition/use-campus-data'
import useBuildingData from '@/composition/use-building-data'

export default Vue.extend({
  components: {
    LMap,
    LDraw,
    LControlZoom,
    LCampusControl,
    LBuildingControl,
    LFloorsControl,
    WithRoomData
  },
  data () {
    return {
      mapObject: (null as unknown) as Map,
      mapOptions: {
        crs: CRS.Simple,
        attributionControl: false,
        minZoom: 1,
        maxZoom: 4,
        zoomControl: false
      },
      floorNumber: null,
      floorImagesReady: false
    }
  },
  computed: {
    buildingNames () {
      const { buildings } = this as any
      return buildings.map((building: any) => building.name)
    }
  },
  setup () {
    const campusData = useCampusData()
    const buildingData = useBuildingData()

    watch(
      [campusData.campusName],
      ([campusName]) => {
        buildingData.getBuildings(campusName)
      }
    )

    return { ...toRefs(campusData), ...toRefs(buildingData) }
  },
  mounted () {
    this.$nextTick(() => {
      this.mapObject = (this.$refs.map as any).mapObject
    })
  }
})
</script>
