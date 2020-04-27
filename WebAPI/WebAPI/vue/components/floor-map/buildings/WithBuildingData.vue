<script lang="ts">
import Vue, { VNode } from 'vue'
import { toRefs } from '@vue/composition-api'
import useBuildingData from '@/composition/use-building-data'

export default Vue.extend({
  props: {
    campusName: { default: 'EHV', type: String }
  },
  setup () {
    const data = useBuildingData()

    data.getBuildings()

    return { ...toRefs(data) }
  },
  render (): VNode {
    const { buildings } = this as any

    return this.$scopedSlots.default!({
      buildings
    }) as any
  }
})
</script>
