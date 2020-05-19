import Repository from './repository'

const resource = '/buildings'

export default {
  getBuildings (campusName?: string) {
    return Repository.get(`${resource}`, {
      params: {
        campusName
      }
    })
  }
}
