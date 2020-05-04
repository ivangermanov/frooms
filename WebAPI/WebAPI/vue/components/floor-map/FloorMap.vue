<template>
  <client-only>
    <l-map
      ref="map"
      :options="mapOptions"
      style="height: 100%; z-index: 0;"
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
            postShape,
            putShapes,
            deleteShapes
          }"
        >
          <div v-if="mapObject">
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
              :campus-names="campusNames"
              :buildings="buildings"
              :map-object="mapObject"
              position="bottomright"
              :floor-number.sync="floorNumber"
            />
            <l-draw
              position="topright"
              :map-object="mapObject"
              :fetched-layers="roomLayers"
              @addLayer="postShape"
              @editLayers="putShapes"
              @deleteLayers="deleteShapes"
            />
          </div>
        </template>
      </with-room-data>
    </l-map>
  </client-only>
</template>
<script lang="ts">
import Vue from 'vue'

import { CRS, Map } from 'leaflet'
import { LMap, LControlZoom } from 'vue2-leaflet'

import { toRefs } from '@vue/composition-api'
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
  computed: {
    buildingNames () {
      const { buildings } = this as any
      return buildings.map((building: any) => building.name)
    }
  },
  setup () {
    const campusData = useCampusData()
    campusData.getCampusNames()

    const buildingData = useBuildingData()
    buildingData.getBuildings()

    return { ...toRefs(campusData), ...toRefs(buildingData) }
  },
  watch: {
    campusNames (value) {
      if (this.campusName === '') { this.campusName = value[0] }
    },
    buildings (value) {
      if (this.buildingName === '') { this.buildingName = value[0].name }
    }
  },
  mounted () {
    this.$nextTick(() => {
      this.mapObject = (this.$refs.map as any).mapObject
    })
  }
})
</script>
