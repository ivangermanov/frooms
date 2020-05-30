import moment from 'moment'
import { reactive, toRefs, computed } from '@vue/composition-api'

export default function useRoomsData () {
  const date = new Date()
  const hours = date.getHours()
  const minutes = date.getMinutes()
  const data = reactive({
    date: date.toISOString().substr(0, 10) as string,
    startTime: `${hours}:${minutes}` as string,
    endTime: `${hours + 1}:${minutes}` as string
  })

  const startDate = computed(() =>
    moment(`${data.date} ${data.startTime}`).toISOString()
  )
  const endDate = computed(() =>
    moment(`${data.date} ${data.endTime}`).toISOString()
  )

  return { ...toRefs(data), startDate, endDate }
}
