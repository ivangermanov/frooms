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
      rooms: {} as {[key: string]: IRoom},
      roomsArray: [] as IRoom[],
      roomLayers: [] as GeoJSON.Feature[]
    }
  },
  computed: {
    saved (): Boolean {
      return this.$store.state.roomAdmin.saved
    }
  },
  watch: {
    rooms () {
      this.roomsArray = Object.values(this.rooms)
      this.roomLayers = this.roomsArray.map(room => IRoomToGeoJSONFeature(room))
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
        rooms.forEach((room) => {
          this.rooms = {
            ...this.rooms,
            [room.number]: room
          }
        })
      }

      fetch()
      setInterval(() => {
        fetch()
      }, 10000)
    },
    async saveShapes (_geoJSON: GeoJSON) {
      if (this.saved) {
        return
      }

      const payload = this.roomsArray

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
      const randNumber = Math.random()
        .toString(36)
        .substring(7)

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
