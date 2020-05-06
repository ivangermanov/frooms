import Repository from './repository'
import { IUser } from '@/types/index'

const resource = '/users'

export default {
  getUser (name: string) {
    return Repository.get(`${resource}`, {
      params: {
        name
      }
    })
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
