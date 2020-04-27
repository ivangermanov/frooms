import Repository from './repository'

const resource = '/buildings'

export default {
  getBuildings () {
    return Repository.get(`${resource}`)
  }
}
