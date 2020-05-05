import roomRepository from './roomRepository'
import userRepository from './userRepository'
import campusRepository from './campusRepository'
import buildingRepository from './buildingRepository'
import floorRepository from './floorRepository'
import fontysApiRepository from './fontysApiRepository'

const repositories = {
  room: roomRepository,
  user: userRepository,
  campus: campusRepository,
  building: buildingRepository,
  floor: floorRepository,
  fontysApi: fontysApiRepository
}

export const RepositoryFactory = repositories
