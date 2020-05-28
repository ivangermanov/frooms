import Repository from '../repository'

const resource = '/admin/users'

export default {
  getUsers () {
    return Repository.get(`${resource}`)
  },
  blockUser (userId: string) {
    return Repository.post(`${resource}/${userId}/block`)
  },
  unblockUser (userId: string) {
    return Repository.post(`${resource}/${userId}/unblock`)
  },
  changeRole (userId: string, role: Number) {
    return Repository.post(`${resource}/${userId}/changeRole?role=${role}`)
  }
}
