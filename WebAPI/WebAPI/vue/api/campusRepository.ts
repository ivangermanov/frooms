import Repository from './repository'

const resource = '/campuses'

export default {
  getCampuses () {
    return Repository.get(`${resource}`)
  },
  getCampusNames () {
    return Repository.get(`${resource}/names`)
  }
}
