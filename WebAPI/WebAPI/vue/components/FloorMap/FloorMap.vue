<template>
  <no-ssr>
    <l-map
      ref="map"
      :options="mapOptions"
      style="height: 100%; padding: 10px; z-index: 0;"
    >
      <l-draw
        v-if="mapObject"
        :map-object="mapObject"
        @saveLayers="saveShapes"
        @addLayer="modifyShapes"
      />
      <l-image-overlay
        :url="overlayOptions.url"
        :bounds="overlayOptions.bounds"
      />
    </l-map>
  </no-ssr>
</template>
<script lang="ts">
import Vue from 'vue'
import { mapMutations } from 'vuex'
import { CRS, GeoJSON, Map } from 'leaflet'
import { LMap, LImageOverlay } from 'vue2-leaflet'
import LDraw from './LDraw.vue'
import { RepositoryFactory } from '@/api/repositoryFactory'
import { IRoom, CreateIRoom } from '@/types'

const RoomRepository = RepositoryFactory.room

export default Vue.extend({
  components: {
    LMap,
    LImageOverlay,
    LDraw
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
        maxBounds: [
          [0, 0],
          [1416, 512]
        ]
      },
      overlayOptions: {
        url: 'https://i.ibb.co/bQYTGBR/floor.png',
        bounds: [
          [0, 0],
          [1416, 512]
        ]
      },
      floor: 2,
      campus: 'eindhoven',
      buildingName: 'r1',
      rooms: [] as IRoom[]
    }
  },
  computed: {
    saved (): Boolean {
      return this.$store.state.roomAdmin.saved
    }
  },
  created () {
    this.fetch()
  },
  mounted () {
    this.$nextTick(() => {
      this.mapObject = (this.$refs.map as any).mapObject
    })
  },
  methods: {
    async fetch () {
      const { data } = await RoomRepository.getRooms(
        this.campus,
        this.buildingName,
        this.floor
      )
      const rooms: IRoom[] = data
      console.log(rooms)
    },
    async saveShapes (_geoJSON: GeoJSON) {
      if (this.saved) {
        return
      }

      const payload = this.rooms

      const success = await RoomRepository.postRooms(payload).catch(() => {})

      if (success) {
        this.setSaved(true)
      }
    },
    modifyShapes (feature: GeoJSON) {
      // Todo: Remove random number
      const randNumber = Math.random()
        .toString(36)
        .substring(7)

      const room = CreateIRoom(
        feature,
        randNumber,
        this.floor,
        this.buildingName
      )
      this.rooms.push(room)
      this.setSaved(false)
    },
    ...mapMutations({
      setSaved: 'roomAdmin/setSaved'
    })
  }
})
</script>
