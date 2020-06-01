import moment from 'moment'
import { reactive, ref, toRefs, computed, onUnmounted } from '@vue/composition-api'

export default function useRoomsData () {
  // TODO: Local time needs to be retrieved from back-end or set as GMT +1 (Netherlands)
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
    currentDate.value.clone().add(3, 'M').format('YYYY-MM-DD')
  )

  const minStart = computed(() => {
    if (startDateMoment.value.isAfter(maxTime) || startDateMoment.value.isBefore(minTime)) {
      return minTime.format('HH:mm')
    }
    return currentDate.value.format('HH:mm')
  })
  const maxStart = computed(() =>
  // TODO: Get max from back-end business logic
    maxTime.clone().subtract(15, 'minutes').format('HH:mm')
  )

  const minEnd = computed(() => {
    // TODO: Get min hours for booking from back-end business logic
    const startOffset = moment(data.startTime, 'HH-mm').add(15, 'minutes')
    return startOffset.isAfter(maxTime) ? maxTime.format('HH:mm') : startOffset.format('HH:mm')
  }
  )
  const maxEnd = computed(() => {
    const startOffset = moment(data.startTime, 'HH-mm').add(3, 'hours')
    return startOffset.isAfter(maxTime) ? maxTime.format('HH:mm') : startOffset.format('HH:mm')
  })

  const startDateMoment = computed(() => moment(`${data.date} ${data.startTime}`))
  const startDate = computed(() => startDateMoment.value.toISOString())
  const endDateMoment = computed(() => moment(`${data.date} ${data.endTime}`))
  const endDate = computed(() => endDateMoment.value.toISOString())

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
