import Repository from './repository'

const resource = '/campuses'

export default {
  getCampuses () {
    return Repository.get(`${resource}`)
  }
}
