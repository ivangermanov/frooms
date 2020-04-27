<script lang="ts">
import Vue, { VNode } from 'vue'
import { toRefs } from '@vue/composition-api'
import useCampusData from '@/composition/use-campus-data'

export default Vue.extend({
  props: {
    campusName: { default: 'EHV', type: String },
    buildingName: { default: 'R1', type: String },
    floorNumber: { default: 'bg', type: String }
  },
  setup () {
    const data = useCampusData()

    data.getCampusNames()

    return { ...toRefs(data) }
  },
  render (): VNode {
    const { campusNames } = this

    return this.$scopedSlots.default!({
      campusNames
    }) as any
  }
})
</script>
