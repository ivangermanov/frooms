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
  },
  getNotifications () {
    return Repository.get(`${resource}/me/notifications`)
  },
  markNotificationRead (notificationId: number) {
    return Repository.post(`${resource}/me/notifications/${notificationId}`)
  },
  markNotificationsRead () {
    return Repository.post(`${resource}/me/notifications`)
  }
}
