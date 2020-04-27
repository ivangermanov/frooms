import { reactive, toRefs } from '@vue/composition-api'

import { RepositoryFactory } from '@/api/repositoryFactory'
const CampusRepository = RepositoryFactory.campus

export default function useRoomsData () {
  const data = reactive({
    campusNames: [] as string[]
  })

  async function getCampusNames () {
    const { data: json } = await CampusRepository.getCampusNames()
    const names: string[] = json
    console.log(names)
    data.campusNames = names
  }

  return { ...toRefs(data), getCampusNames }
}
