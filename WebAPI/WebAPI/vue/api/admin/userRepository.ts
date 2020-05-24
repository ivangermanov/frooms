import Repository from '../repository'
import { IUser } from '@/types/index'

const resource = '/admin/users'

export default {
  getUsers () {
    return Repository.get(`${resource}`)
  },
  blockUser(userId: string) {
    return Repository.post(`${resource}/${userId}/block`)
  },
  unblockUser(userId: string) {
    return Repository.post(`${resource}/${userId}/unblock`)
  }
}
