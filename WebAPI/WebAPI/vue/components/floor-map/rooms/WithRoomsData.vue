<script lang="ts">
import Vue, { VNode } from 'vue'
import { mapMutations } from 'vuex'
import { GeoJSON } from 'leaflet'
import { IRoom, CreateIRoom, IRoomToGeoJSONFeature } from '@/types'

import { RepositoryFactory } from '@/api/repositoryFactory'
const RoomRepository = RepositoryFactory.room

export default Vue.extend({
  data () {
    return {
      floor: 2,
      campus: 'eindhoven',
      buildingName: 'r1',
      rooms: {} as { [key: string]: IRoom },
      changedRooms: {} as { [key: string]: IRoom },
      roomLayers: {} as { [key: string]: GeoJSON.Feature }
    }
  },
  computed: {
    saved (): Boolean {
      return this.$store.state.roomAdmin.saved
    },
    editMode (): Boolean {
      return this.$store.state.roomAdmin.editMode
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
      if (this.editMode) { return }

      const { data } = await RoomRepository.getRooms(
        this.campus,
        this.buildingName,
        this.floor
      )
      const rooms: IRoom[] = data
      const newRooms = {} as { [key: string]: IRoom }
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
    async saveShapes () {
      if (this.saved) {
        return
      }

      const payload = Object.values(this.changedRooms)

      const success = await RoomRepository.postRooms(payload).catch(() => {})

      if (success) {
        this.changedRooms = {}
        this.setSaved(true)
      }
    },
    ...mapMutations({
      setSaved: 'roomAdmin/setSaved'
    }),
    changeShapes (shape: GeoJSON.Feature) {
      const room = CreateIRoom(shape, this.floor, this.buildingName)

      Vue.set(this.changedRooms, room.number, room)
      this.setSaved(false)
    }
  },
  render (): VNode {
    const { roomLayers, saveShapes, changeShapes } = this

    return this.$scopedSlots.default!({
      roomLayers,
      saveShapes,
      changeShapes
    }) as any
  }
})
</script>
