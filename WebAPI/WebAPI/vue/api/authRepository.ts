import Repository from './repository'

const resource = '/auth'

export default {
  getUserInfo () {
    return Repository.post(`${resource}`)
  }
}
