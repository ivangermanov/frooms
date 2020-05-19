import { reactive, toRefs, watch } from '@vue/composition-api'

import { RepositoryFactory } from '@/api/repositoryFactory'
const CampusRepository = RepositoryFactory.campus

export default function useRoomsData () {
  const data = reactive({
    campusName: null as unknown as string,
    campusNames: [] as string[]
  })

  async function getCampusNames () {
    const { data: json } = await CampusRepository.getCampusNames()
    const names: string[] = json
    data.campusNames = names
  }

  watch(
    () => [data.campusNames],
    ([campusNames]) => {
      if (!data.campusName && campusNames[0]) { data.campusName = campusNames[0] }
    }
  )

  getCampusNames()

  return toRefs(data)
}
