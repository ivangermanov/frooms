<script lang="ts">
import Vue, { VNode } from 'vue'
import { computed, watch, toRefs } from '@vue/composition-api'
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

    watch(() => editMode, (val) => {
      if (!val) {
        data.getRooms()
      }
    })

    function getRooms () {
      if (editMode.value || deleteMode.value) { return }
      data.getRooms()
      setTimeout(() => {
        data.getRooms()
        getRooms()
      }, 5000)
    }

    getRooms()

    console.log(data)

    return { ...toRefs(data), getRooms, editMode, deleteMode }
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
