import Repository from './repository'

const resource = '/floors'

export default {
  getFloors (buildingName: string) {
    return Repository.get(`${resource}`, {
      params: {
        buildingName
      }
    })
  }
}
