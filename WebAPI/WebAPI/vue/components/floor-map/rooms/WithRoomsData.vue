<script lang="ts">
import Vue, { VNode } from 'vue'
import { mapMutations } from 'vuex'
import { GeoJSON } from 'leaflet'
import { IRoomDTO, IRoomModel, CreateIRoomModel, IRoomToGeoJSONFeature } from '@/types'

import { RepositoryFactory } from '@/api/repositoryFactory'
const RoomRepository = RepositoryFactory.room

export default Vue.extend({
  data () {
    return {
      campusName: 'EHV',
      buildingName: 'R1',
      floor: '2e',
      rooms: {} as { [key: string]: IRoomDTO },
      roomLayers: {} as { [key: string]: GeoJSON.Feature }
    }
  },
  computed: {
    editMode (): Boolean {
      return this.$store.state.roomAdmin.editMode
    },
    deleteMode (): Boolean {
      return this.$store.state.roomAdmin.deleteMode
    }
  },
  watch: {
    editMode (val) {
      if (!val) {
        this.fetch()
      }
    }
  },
  created () {
    this.fetch()
  },
  methods: {
    async fetch () {
      if (this.editMode || this.deleteMode) { return }

      const { data } = await RoomRepository.getRooms(
        this.campusName,
        this.buildingName,
        this.floor
      )
      const rooms: IRoomDTO[] = data
      const newRooms = {} as { [key: string]: IRoomDTO }
      const newRoomLayers = {} as { [key: string]: GeoJSON.Feature }

      rooms.forEach((room) => {
        newRooms[room.number] = room
        newRoomLayers[room.number] = IRoomToGeoJSONFeature(room)
      })
      this.rooms = newRooms
      this.roomLayers = newRoomLayers

      setTimeout(() => {
        this.fetch()
      }, 5000)
    },
    async postShape (shape: GeoJSON.Feature) {
      const payload = [CreateIRoomModel(shape, this.floor, this.buildingName, this.campusName)]

      const success = await RoomRepository.postRooms(payload).catch(() => {})

      if (success) {

      }
    },
    async putShapes (shapes: GeoJSON) {
      const payload: IRoomModel[] = []
      shapes.eachLayer((layer: any) => {
        const shape = layer.toGeoJSON()
        const room = CreateIRoomModel(shape, this.floor, this.buildingName, this.campusName)
        payload.push(room)
      })

      await RoomRepository.putRooms(payload).catch(() => {})
    },
    async deleteShapes (shapes: GeoJSON) {
      const payload: IRoomModel[] = []
      shapes.eachLayer((layer: any) => {
        const shape = layer.toGeoJSON()
        const room = CreateIRoomModel(shape, this.floor, this.buildingName, this.campusName)
        payload.push(room)
      })

      await RoomRepository.deleteRooms(payload).catch(() => {})
    },
    ...mapMutations({
      setSaved: 'roomAdmin/setSaved'
    })
  },
  render (): VNode {
    const { roomLayers, postShape, putShapes, deleteShapes } = this

    return this.$scopedSlots.default!({
      roomLayers,
      postShape,
      putShapes,
      deleteShapes
    }) as any
  }
})
</script>
