<template>
  <client-only>
    <l-map ref="map" :options="mapOptions" style="height: 100vh; z-index: 0;">
      <l-control-zoom position="topright" />

      <with-room-data
        :campus-name="campusName"
        :building-name="buildingName"
        :floor-number="floorNumber"
        :start-date="startDate"
        :end-date="endDate"
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
            <l-control position="topleft" class="topleft-control-panel">
              <l-campus-control
                :campus-name.sync="campusName"
                :campuses="campusNames"
              />
              <l-building-control
                :building-name.sync="buildingName"
                :buildings="buildingNames"
              />
              <l-date-control :date.sync="date" :min="minDate" :max="maxDate" />
              <l-time-control
                label="Start time"
                icon="mdi-clock-time-four"
                :time.sync="startTime"
                :min="minStart"
                :max="maxStart"
              />
              <l-time-control
                label="End time"
                icon="mdi-clock-time-nine"
                :time.sync="endTime"
                :min="minEnd"
                :max="maxEnd"
              />
              <l-floors-control
                :map-object="mapObject"
                :campus-names="campusNames"
                :buildings="buildings"
                :floors="floors"
                :floor-number.sync="floorNumber"
                position="bottomright"
                @fetchedFloors="value => (floorImagesReady = value)"
              />
            </l-control>
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
import { LMap, LControlZoom, LControl } from 'vue2-leaflet'

import { toRefs, watch } from '@vue/composition-api'
import LDraw from './rooms/draw/LDraw.vue'
import LFloorsControl from './rooms/floors/LFloorsControl.vue'
import LCampusControl from './campuses/LCampusControl.vue'
import LBuildingControl from './buildings/LBuildingControl.vue'
import LDateControl from './dates/LDateControl.vue'
import LTimeControl from './time/LTimeControl.vue'
import WithRoomData from './rooms/WithRoomData.vue'
import useCampusData from '@/composition/use-campus-data'
import useBuildingData from '@/composition/use-building-data'
import useFloorMapDates from '@/composition/use-floor-map-dates'

export default Vue.extend({
  components: {
    LMap,
    LDraw,
    LControlZoom,
    LCampusControl,
    LControl,
    LBuildingControl,
    LDateControl,
    LTimeControl,
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
    const dates = useFloorMapDates()

    watch([campusData.campusName], ([campusName]) => {
      buildingData.getBuildings(campusName)
    })

    return { ...toRefs(campusData), ...toRefs(buildingData), ...toRefs(dates) }
  },
  mounted () {
    this.$nextTick(() => {
      this.mapObject = (this.$refs.map as any).mapObject
    })
  }
})
</script>
<style>
.topleft-control-panel {
  display: grid;
  grid-row-gap: 10px;
  grid-template-rows: "1fr 1fr 1fr";
  width: 165px;
}
</style>
