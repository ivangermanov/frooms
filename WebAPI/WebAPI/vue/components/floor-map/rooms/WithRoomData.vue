<script lang="ts">
import Vue, { VNode } from 'vue'
import {
  computed,
  watch,
  toRefs,
  ref,
  onBeforeUnmount
} from '@vue/composition-api'
import useRoomData from '@/composition/use-room-data'

export default Vue.extend({
  props: {
    campusName: { default: null, type: String },
    buildingName: { default: null, type: String },
    floorNumber: { default: null, type: String },
    startDate: { default: null, type: String },
    endDate: { default: null, type: String }
  },
  setup (props, context) {
    const data = useRoomData(props)
    const editMode = computed(
      () => context.root.$store.state.roomAdmin.editMode
    )
    const deleteMode = computed(
      () => context.root.$store.state.roomAdmin.deleteMode
    )
    const fetchInterval = ref(setInterval(data.getRooms, 5000))

    onBeforeUnmount(() => {
      clearInterval(fetchInterval.value)
    })

    watch([editMode, deleteMode], ([editMode, deleteMode]) => {
      clearInterval(fetchInterval.value)
      if (editMode || deleteMode) {
        return
      }

      fetchInterval.value = setInterval(data.getRooms, 5000)
    })

    watch(
      () => [props.campusName, props.buildingName],
      ([campusName, buildingName]) => {
        if (campusName && buildingName) {
          data.getFloors()
        }
      }
    )

    watch(
      () => [props.campusName, props.buildingName, props.floorNumber],
      ([campusName, buildingName, floorNumber]) => {
        if (
          campusName !== null &&
          buildingName !== null &&
          floorNumber !== null
        ) {
          data.getRooms()
        }
      }
    )

    return { ...toRefs(data) }
  },
  render (): VNode {
    const { roomLayers, floors, postShape, putShapes, deleteShapes } = this as any

    return this.$scopedSlots.default!({
      roomLayers,
      floors,
      postShape,
      putShapes,
      deleteShapes
    }) as any
  }
})
</script>
