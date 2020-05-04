import { reactive, toRefs } from '@vue/composition-api'

import { RepositoryFactory } from '@/api/repositoryFactory'
const BuildingRepository = RepositoryFactory.building

export default function useRoomsData () {
  const data = reactive({
    buildings: []
  })

  async function getBuildings () {
    const { data: json } = await BuildingRepository.getBuildings()
    const buildings = json
    console.log(buildings)
    data.buildings = buildings
  }

  return { ...toRefs(data), getBuildings }
}
