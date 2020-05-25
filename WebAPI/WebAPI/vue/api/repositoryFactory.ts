import roomRepository from './roomRepository'
import userRepository from './userRepository'
import campusRepository from './campusRepository'
import reservationRepository from './reservationRepository'
import buildingRepository from './buildingRepository'
import floorRepository from './floorRepository'
import fontysApiRepository from './fontysApiRepository'
import adminUserRepository from './admin/userRepository'

const repositories = {
  room: roomRepository,
  campus: campusRepository,
  user: userRepository,
  reservation: reservationRepository,
  building: buildingRepository,
  floor: floorRepository,
  fontysApi: fontysApiRepository,
  adminUser: adminUserRepository
}

export const RepositoryFactory = repositories
