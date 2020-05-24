import Repository from '../repository'
import { IUser } from '@/types/index'

const resource = '/admin/users'

export default {
  getUsers () {
    return Repository.get(`${resource}`)
  }
}
