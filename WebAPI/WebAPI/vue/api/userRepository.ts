import Repository from './repository'

const resource = '/users'

export default {
  getUserInfo () {
    return Repository.get(`${resource}/me`)
  },
  getUserRoles () {
    return Repository.get(`${resource}/me/roles`)
  }
}
