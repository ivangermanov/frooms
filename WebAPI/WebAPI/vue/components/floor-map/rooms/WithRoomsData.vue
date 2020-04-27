<script lang="ts">
import Vue, { VNode } from 'vue'
import { computed, watch, toRefs, ref, onBeforeUnmount } from '@vue/composition-api'
import useRoomsData from '@/composition/use-rooms-data'

export default Vue.extend({
  props: {
    campusName: { default: 'EHV', type: String },
    buildingName: { default: 'R1', type: String },
    floorNumber: { default: 'bg', type: String }
  },
  setup (props, context) {
    const data = useRoomsData({
      campusName: props.campusName as string,
      buildingName: props.buildingName as string,
      floorNumber: props.floorNumber as string
    })
    const editMode = computed(() => context.root.$store.state.roomAdmin.editMode)
    const deleteMode = computed(() => context.root.$store.state.roomAdmin.deleteMode)
    const fetchInterval = ref(setInterval(data.getRooms, 5000))

    onBeforeUnmount(() => {
      clearInterval(fetchInterval.value)
    })

    watch([editMode, deleteMode], ([editMode, deleteMode]) => {
      clearInterval(fetchInterval.value)
      if (editMode || deleteMode) { return }

      fetchInterval.value = setInterval(data.getRooms, 5000)
    })

    data.getRooms()

    return { ...toRefs(data) }
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
