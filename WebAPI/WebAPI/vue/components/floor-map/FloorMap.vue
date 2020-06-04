<template>
  <div style="height: 100%">
    <!-- TODO: Show spinner while loading -->
    <client-only>
      <l-map ref="map" :options="mapOptions" style="height: 100%; z-index: 0;">
        <l-control-zoom position="topright" />

        <with-room-data
          :campus-name="reservationDetails.campus"
          :building-name="reservationDetails.building"
          :floor-number="reservationDetails.floor"
          :start-date="reservationDetails.startDate"
          :end-date="reservationDetails.endDate"
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
                  :campus-name.sync="reservationDetails.campus"
                  :campuses="campusNames"
                />
                <l-building-control
                  :building-name.sync="reservationDetails.building"
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
                  :floor-number.sync="reservationDetails.floor"
                  position="bottomright"
                  @fetchedFloors="value => (floorImagesReady = value)"
                />
              </l-control>
              <fragment v-if="floorImagesReady">
                <l-draw
                  position="topright"
                  :map-object="mapObject"
                  :fetched-layers="roomLayers"
                  :selected-room="reservationDetails.room"
                  @select-room="value => reservationDetails.room = value"
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
    <portal to="modals">
      <reserve-modal
        v-if="reservationDetails.room"
        :external-reservation-details="reservationDetails"
        :skip="true"
        @close="reservationDetails.room = null"
      />
    </portal>
  </div>
</template>
<script lang="ts">
import Vue from 'vue'

import { CRS, Map } from 'leaflet'
import { LMap, LControlZoom, LControl } from 'vue2-leaflet'

import { toRefs, watch, reactive } from '@vue/composition-api'
import LDraw from './rooms/draw/LDraw.vue'
import LFloorsControl from './rooms/floors/LFloorsControl.vue'
import LCampusControl from './campuses/LCampusControl.vue'
import LBuildingControl from './buildings/LBuildingControl.vue'
import LDateControl from './dates/LDateControl.vue'
import LTimeControl from './time/LTimeControl.vue'
import WithRoomData from './rooms/WithRoomData.vue'
import ReserveModal from '@/components/reserve-room/ReserveModal.vue'
import useCampusData from '@/composition/use-campus-data'
import useBuildingData from '@/composition/use-building-data'
import useReservationDates from '@/composition/use-reservation-dates'

// @ts-ignore
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
    WithRoomData,
    ReserveModal
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
    const { campusName, ...restCampus } = useCampusData()
    // TODO: Could extract date and time to a with-date-and-time HOC wrapper
    const { buildingName, ...restBuildings } = useBuildingData()
    const { startDate, endDate, ...restDates } = useReservationDates()

    const reservationDetails = reactive({
      campus: campusName,
      building: buildingName,
      floor: null,
      room: null,
      startDate,
      endDate
    })

    watch([campusName], ([campusName]) => {
      restBuildings.getBuildings(campusName)
    })

    return { reservationDetails, ...toRefs(restCampus as any), ...toRefs(restBuildings as any), ...toRefs(restDates as any) }
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
