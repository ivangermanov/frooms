import moment from 'moment'
import { reactive, ref, toRefs, computed, onUnmounted } from '@vue/composition-api'

export default function useRoomsData () {
  const currentDate = ref(moment())
  // TODO: Get start time and end time for reservations from back-end business logic
  const minTime = moment('9:00', 'HH:mm')
  const maxTime = moment('17:00', 'HH:mm')
  const data = reactive({
    date: currentDate.value.format('YYYY-MM-DD') as string,
    startTime: currentDate.value.format('HH:mm') as string,
    // TODO: Get max reservation time from back-end business logic
    endTime: currentDate.value
      .clone()
      .add(3, 'hour')
      .format('HH:mm') as string
  })

  const minDate = computed(() => {
    if (currentDate.value.isAfter(maxTime)) {
      return currentDate.value.clone().add(1, 'day').format('YYYY-MM-DD')
    }
    return currentDate.value.format('YYYY-MM-DD')
  })
  const maxDate = computed(() =>
  // TODO: Get months in advance from back-end business logic
    currentDate.value.add(3, 'M').format('YYYY-MM-DD')
  )

  const minStart = computed(() => {
    if (currentDate.value.isAfter(maxTime)) {
      return minTime.format('HH:mm')
    }
    return currentDate.value.format('HH:mm')
  })
  const maxStart = computed(() =>
  // TODO: Get max from back-end business logic
    maxTime.clone().subtract(1, 'hour').format('HH:mm')
  )

  const minEnd = computed(() =>
    // TODO: Get min hours for booking from back-end business logic
    moment(startDate.value)
      .add(15, 'minutes')
      .format('HH:mm')
  )
  const maxEnd = computed(() => {
    if (moment(data.startTime, 'HH-mm').add(3, 'hours').isAfter(maxTime)) {
      return maxTime.format('HH:mm')
    }
    return moment(startDate.value).add(3, 'hours').format('HH:mm')
  })

  const startDate = computed(() =>
    moment(`${data.date} ${data.startTime}`).toISOString()
  )
  const endDate = computed(() =>
    moment(`${data.date} ${data.endTime}`).toISOString()
  )

  let timer: NodeJS.Timeout
  function updateCurrentDate () {
    const remaining = (60 - currentDate.value.seconds()) * 1000
    timer = setTimeout(() => {
      currentDate.value = moment()
      updateCurrentDate()
    }, remaining)
  }

  onUnmounted(() => {
    clearTimeout(timer)
  })

  updateCurrentDate()

  return {
    ...toRefs(data),
    startDate,
    endDate,
    minDate,
    maxDate,
    minStart,
    maxStart,
    minEnd,
    maxEnd
  }
}
