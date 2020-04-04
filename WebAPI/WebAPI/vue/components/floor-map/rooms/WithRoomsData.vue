<script lang="ts">
import Vue, { VNode } from 'vue'
import { mapMutations } from 'vuex'
import { GeoJSON, Polyline } from 'leaflet'
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
      roomLayers: {} as { [key: string]: GeoJSON.Feature }
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
  methods: {
    fetch () {
      const fetch = async () => {
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
      }

      fetch()
      setInterval(() => {
        fetch()
      }, 5000)
    },
    async saveShapes (_geoJSON: GeoJSON) {
      if (this.saved) {
        return
      }

      const payload = Object.values(this.rooms)

      const success = await RoomRepository.postRooms(payload).catch(() => {})

      if (success) {
        this.setSaved(true)
      }
    },
    ...mapMutations({
      setSaved: 'roomAdmin/setSaved'
    }),
    modifyShapes (shape: Polyline) {
      // TODO: Remove random number
      const randNumber = Math.random().toString(36).substring(7)

      const room = CreateIRoom(
        shape,
        randNumber,
        this.floor,
        this.buildingName
      )
      this.rooms = {
        ...this.rooms,
        [room.number]: room
      }
      this.setSaved(false)
    }
  },
  render (): VNode {
    const { roomLayers, saveShapes, modifyShapes } = this

    return this.$scopedSlots.default!({
      roomLayers,
      saveShapes,
      modifyShapes
    }) as any
  }
})
</script>
