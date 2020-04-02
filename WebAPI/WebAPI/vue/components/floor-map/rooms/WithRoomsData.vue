<script lang="ts">
import Vue, { VNode } from 'vue'
import { mapMutations } from 'vuex'
import { GeoJSON } from 'leaflet'
import { IRoom, CreateIRoom, IRoomToGeoJSON } from '@/types'

import { RepositoryFactory } from '@/api/repositoryFactory'
const RoomRepository = RepositoryFactory.room

export default Vue.extend({
  data () {
    return {
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
    ...mapMutations({
      setSaved: 'roomAdmin/setSaved'
    }),
    modifyShapes (feature: GeoJSON) {
      // TODO: Remove random number
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
    }
  },
  render (): VNode {
    const { rooms } = this.$data
    const { saveShapes, modifyShapes } = this

    return this.$scopedSlots.default!({
      rooms,
      saveShapes,
      modifyShapes
    }) as any
  }
})
</script>
