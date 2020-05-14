import Repository from './repository'
import { IUser, IPostUser } from '@/types/index'

const resource = '/users'

export default {
  findOrCreateUser (payload: IPostUser) {
    return Repository.post(`${resource}/findorcreate`, payload)
  },
  postUser (payload: IUser) {
    return Repository.post(`${resource}`, payload)
  },
  getUserInfo () {
    return Repository.get(`${resource}/me`)
  },
  getUserRoles () {
    return Repository.get(`${resource}/me/roles`)
  }
}
