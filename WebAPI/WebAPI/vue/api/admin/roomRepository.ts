import Repository from '../repository'

const resource = '/admin/rooms'

export default {
  getAllRooms () {
    return Repository.get(`${resource}/`)
  }
}
