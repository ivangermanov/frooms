import Repository from './repository'

const resource = '/auth'

export default {
  getUserInfo () {
    return Repository.get(`${resource}`)
  }
}
