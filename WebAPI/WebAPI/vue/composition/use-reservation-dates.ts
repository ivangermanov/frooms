import moment from 'moment'
import { reactive, ref, toRefs, computed, onUnmounted, watch, onMounted } from '@vue/composition-api'
import { RepositoryFactory } from '@/api/repositoryFactory'
const ReservationRepository = RepositoryFactory.reservation

export default function useRoomsData () {
  const currentDate = ref(moment())
  const minTime = ref(moment('9:00', 'HH:mm'))
  const maxTime = ref(moment('17:00', 'HH:mm'))
  // 15 minutes
  const minReservationTime = ref(900000)
  // 3 hours
  const maxReservationTime = ref(10800000)
  // 3 months
  const maxForwardReservationPeriod = ref(7776000000)

  const data = reactive({
    date: currentDate.value.format('YYYY-MM-DD'),
    startTime: currentDate.value.format('HH:mm'),
    endTime: currentDate.value
      .clone()
      .add(maxReservationTime.value, 'milliseconds')
      .format('HH:mm')
  })

  const minDate = computed(() => {
    if (currentDate.value.isAfter(maxTime.value)) {
      return currentDate.value.clone().add(1, 'day').format('YYYY-MM-DD')
    }
    return currentDate.value.format('YYYY-MM-DD')
  })
  const maxDate = computed(() =>
    currentDate.value.clone()
      .add(maxForwardReservationPeriod.value, 'milliseconds')
      .format('YYYY-MM-DD')
  )

  const minStart = computed(() => {
    if (startDateMoment.value.isAfter(maxTime.value) || startDateMoment.value.isBefore(minTime.value)) {
      return minTime.value.format('HH:mm')
    }
    return currentDate.value.format('HH:mm')
  })
  const maxStart = computed(() =>
    maxTime.value.clone().subtract(minReservationTime.value, 'milliseconds').format('HH:mm')
  )

  const minEnd = computed(() => {
    const startOffset = moment(data.startTime, 'HH-mm').add(minReservationTime.value, 'milliseconds')
    return startOffset.isAfter(maxTime.value) ? maxTime.value.format('HH:mm') : startOffset.format('HH:mm')
  }
  )
  const maxEnd = computed(() => {
    const startOffset = moment(data.startTime, 'HH-mm').add(maxReservationTime.value, 'milliseconds')
    return startOffset.isAfter(maxTime.value) ? maxTime.value.format('HH:mm') : startOffset.format('HH:mm')
  })

  const startDateMoment = computed(() => moment(`${data.date} ${data.startTime}`))
  const startDate = computed(() => startDateMoment.value.toISOString(true))
  const endDateMoment = computed(() => moment(`${data.date} ${data.endTime}`))
  const endDate = computed(() => endDateMoment.value.toISOString(true))

  watch([startDate, minStart, maxStart], () => {
    const min = moment(minStart.value, 'HH:mm')
    const max = moment(maxStart.value, 'HH:mm')
    const current = moment(data.startTime, 'HH:mm')
    if (current.isAfter(max) || current.isBefore(min)) {
      data.startTime = min.format('HH:mm')
    }
  })

  watch([endDate, minEnd, maxEnd], () => {
    const min = moment(minEnd.value, 'HH:mm')
    const max = moment(maxEnd.value, 'HH:mm')
    const current = moment(data.endTime, 'HH:mm')
    if (current.isAfter(max) || current.isBefore(min)) {
      data.endTime = min.format('HH:mm')
    }
  })

  let timer: NodeJS.Timeout
  function updateCurrentDate () {
    const remaining = (60 - currentDate.value.seconds()) * 1000
    timer = setTimeout(() => {
      const curMoment = moment()
      currentDate.value = curMoment
      updateCurrentDate()
      if (startDateMoment.value.isBefore(curMoment)) {
        data.date = curMoment.format('YYYY-MM-DD')
        data.startTime = curMoment.format('HH:mm')
      }
    }, remaining)
  }

  onMounted(async () => {
    const { data } = await ReservationRepository.getRules()
    currentDate.value = moment(data.currentDate)
    minTime.value = moment(data.minTime)
    maxTime.value = moment(data.maxTime)
    minReservationTime.value = data.minReservationTime
    maxReservationTime.value = data.maxReservationTime
    clearTimeout(timer)
    updateCurrentDate()
  })

  onUnmounted(() => {
    clearTimeout(timer)
  })

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
