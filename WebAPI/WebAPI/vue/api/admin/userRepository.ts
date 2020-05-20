import Repository from '../repository'
import { IUser } from '@/types/index'

const resource = '/users'

export default {
  getUsers () {
    return Repository.get(`${resource}`)
  }
}
