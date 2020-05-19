import { reactive, toRefs, watch } from '@vue/composition-api'

import { RepositoryFactory } from '@/api/repositoryFactory'
const BuildingRepository = RepositoryFactory.building

export default function useRoomsData (
) {
  const data = reactive({
    buildingName: null as unknown as string,
    buildings: [] as any[]
  })

  async function getBuildings (campusName?: string) {
    const { data: json } = await BuildingRepository.getBuildings(campusName)
    const buildings = json
    data.buildings = buildings
  }

  watch(
    () => [data.buildings],
    ([buildingNames]) => {
      if (!data.buildingName && buildingNames[0]) { data.buildingName = buildingNames[0].name }
    }
  )

  getBuildings()

  return { ...toRefs(data), getBuildings }
}
